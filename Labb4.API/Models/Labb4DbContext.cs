using Labb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4.API.Models
{
    public class Labb4DbContext : DbContext
    {
        public Labb4DbContext(DbContextOptions<Labb4DbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                FirstName = "Lucas",
                LastName = "Narfgren",
                Adress = "Hertings Allé 5A",
                Phone = "0707409223",

            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                FirstName = "Johnny",
                LastName = "karlsson",
                Adress = "Kalles Allé 5A",
                Phone = "034534423",
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 3,
                FirstName = "Conny",
                LastName = "Svensson",
                Adress = "Svens Allé 5A",
                Phone = "098098764",
            });

            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 1, Title = "Golf", Description = "Spela Golf", PersonId = 1 });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 2, Title = "Racing", Description = "Köra Fort", PersonId = 2 });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 3, Title = "Skytte", Description = "Skjuta vilt", PersonId = 3 });

            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 1, URL = "https://www.vinbergsgolfklubb.se/", InterestId = 1 });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 2, URL = "https://www.falkenbergsmk.se/", InterestId = 2 });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 3, URL = "https://www.pistolskytteforbundet.se/", InterestId = 3 });
        }
    }
}
