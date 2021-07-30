using Entity.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-DR7EADTJ\SQLEXPRESS;Initial Catalog=DbProjetCamp;Integrated Security=True");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<BadgeStyle> BadgeStyles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }

}
