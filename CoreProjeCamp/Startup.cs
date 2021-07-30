using Core.DependencyResolvers;
using Core.Utilities.IoC;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Session;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjeCamp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Index";
                    options.Cookie.Name = "AshProgHelpCookie";
                });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().
                    RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
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
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(name: "defalut", pattern: "{Controller=Login}/{Action=Index}/{id?}");
            });




        }
    }
}
