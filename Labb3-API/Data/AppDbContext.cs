using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Labb3_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonID = 1,
                FirstName = "Isac",
                LastName = "Elfstrand",
                PhoneNumber = "0710101010"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonID = 2,
                FirstName = "Anas",
                LastName = "Qlok",
                PhoneNumber = "0734567891"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonID = 3,
                FirstName = "Tobias",
                LastName = "Qlok",
                PhoneNumber = "0776543210"
            });





            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 1,
                InterestName = "Allsvenskan",
                InterestDescription = "Watching the Swedish Football League Allsvenskan."

            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 2,
                InterestName = "Gym",
                InterestDescription = "Going to the gym to lifting heavy weights."
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 3,
                InterestName = "Gaming",
                InterestDescription = "Playing games on various platforms, for example computers, consoles and phones."

            });



            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkID = 1,
                Url = "www.fotbollskanalen.se",
                PersonInterestID = 1
            });

            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkID = 2,
                Url = "www.friskissvettis.se",
                PersonInterestID = 2
            });

            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkID = 3,
                Url = "www.store.steampowered.com",
                PersonInterestID = 3
            });



            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestID = 1,
                PersonID = 1,
                InterestID = 1,
            });

            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestID = 2,
                PersonID = 2,
                InterestID = 2,
            });

            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestID = 3,
                PersonID = 3,
                InterestID = 3,
            });
        }
    }
}

