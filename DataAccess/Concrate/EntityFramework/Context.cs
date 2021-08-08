
using Entity.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate.EntityFramework
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-DR7EADTJ\SQLEXPRESS;Initial Catalog=DbProjetCamp;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<SkilssCard> skilssCards { get; set; }
        public DbSet<BadgeStyle> BadgeStyles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Image> Images { get; set; }
    }

}
