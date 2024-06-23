using API_Intro.Helpers.EntityConfigurations;
using API_Intro.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API_Intro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        public DbSet<Category> Categories { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Slider> Sliders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CityConfigurations());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<Country>()
            //    .Property(s => s.Population)
            //    .HasColumnName("Population")
            //    .HasDefaultValue(0)
            //    .IsRequired();



            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = 1,
                   Name = "UX",
                   CreatedDate = DateTime.Now,
               },
            new Category
            {
                Id = 2,
                Name = "Design",
                CreatedDate = DateTime.Now,
            },
            new Category
            {
                Id = 3,
                Name = "Backend",
                CreatedDate = DateTime.Now,
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
