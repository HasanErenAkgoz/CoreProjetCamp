using DataAccess.IdentitysContext;
using Entity.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CoreProjeCamp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration _configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Account/Login/";
            });
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, AppRole>(setting =>
            {
                setting.Password.RequiredLength = 5;
                setting.Password.RequireNonAlphanumeric = false;
                setting.Password.RequireUppercase = true;
                setting.Password.RequireLowercase = true;
                setting.Password.RequireDigit = false;
            }
            ).AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(_ =>
            {
                _.LoginPath = new PathString("/Account/Login");
                _.LogoutPath = new PathString("/Account/Logout");
                _.Cookie = new CookieBuilder
                {
                    Name = "AspNetCoreIdentityExampleCookie", //Oluþturulacak Cookie'yi isimlendiriyoruz.
                    HttpOnly = false, //Kötü niyetli insanlarýn client-side tarafýndan Cookie'ye eriþmesini engelliyoruz.
                    SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtiyoruz.
                    SecurePolicy = CookieSecurePolicy.Always //HTTPS üzerinden eriþilebilir yapýyoruz.
                };
                _.SlidingExpiration = true; //Expiration süresinin yarýsý kadar süre zarfýnda istekte bulunulursa eðer geri kalan yarýsýný tekrar sýfýrlayarak ilk ayarlanan süreyi tazeleyecektir.
                _.ExpireTimeSpan = TimeSpan.FromMinutes(2); //CookieBuilder nesnesinde tanýmlanan Expiration deðerinin varsayýlan deðerlerle ezilme ihtimaline karþ ýn tekrardan Cookie vadesi burada da belirtiliyor.
                _.AccessDeniedPath = new PathString("/authority/page");
            });

            services.AddSession();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/Index");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseMvc(_ => _.MapRoute("Default", "{controller=Account}/{action=Login}/{id?}"));




        }
    }
}
