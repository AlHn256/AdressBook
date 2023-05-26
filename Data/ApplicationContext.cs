using Microsoft.EntityFrameworkCore;
using WebAppMVC3.Models;

namespace WebAppMVC3.Data
{
    
    public class ApplicationContext : DbContext
    {
        //public DbSet<AdressBook> AdressBook { get; set; } = null!;
        public DbSet<AdressBook> AdressBook { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdressBook>().HasData(
                    new AdressBook { Id = 1, Email = "Tom@mail.com",  FIO = "Tom Yang" , Birthday = DateTime.Now},
                    new AdressBook { Id = 2, Email = "Bob@mail.com", FIO = "Bob Tornton", Birthday = DateTime.Now },
                    new AdressBook { Id = 3, Email = "Jone@mail.com", FIO = "Jone Silver", Birthday = DateTime.Now }
            );
        }
    }
}
