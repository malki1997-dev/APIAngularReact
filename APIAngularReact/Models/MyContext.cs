using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIAngularReact.Models
{
    public class MyContext : IdentityDbContext<User>
    {

        public DbSet<Taske> Taskes {get;set;}

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Taske>()
                .HasKey(t => t.Id);
        }

    }
}
