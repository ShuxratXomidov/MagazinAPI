using MagazinAPI.Models;
using Microsoft.EntityFrameworkCore;
using MagazinAPI.Models;

namespace MagazinAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<User> users = new List<User>()
            //User user = new User()
            //{
            //    FirstName = "",
            //    LastName = "",
            //    Age = 1,
            //};
            //users.Add(new User()
            //{
            //    FirstName = "Shuxrat",
            //    LastName = "Xomidov",
            //    Age = 31
            //});
            {
                new User { Id = 1, FirstName = "Shuxrat", LastName = "Xomidov", Age = 31 },
                new User { Id = 2, FirstName = "Maruf", LastName = "Ergashev", Age = 32},
            };

            modelBuilder.Entity<User>().HasData(users);

            base.OnModelCreating(modelBuilder);
        }
    }
}
