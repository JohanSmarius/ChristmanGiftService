using Microsoft.EntityFrameworkCore;
using SantaTest.Models;

namespace SantaTest.Data
{
    public class GiftContext : DbContext
    {
        public GiftContext(DbContextOptions<GiftContext> options) : base(options)
        {
        }

        public DbSet<Child> Children { get; set; } = default!;
        public DbSet<Family> Families { get; set; } = default!;
        public DbSet<Gift> Gifts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address {  Id = 1, City = "New York", StreetName = "Avenue", HouseNumber = "5000"},
                new Address {  Id = 2, City = "Tilburg", StreetName = "Kerklaan", HouseNumber = "1"});

            modelBuilder.Entity<Family>().HasData(
                new Family
                {
                    Id = 1,
                    Name = "Smith",
                    AddressId = 1
                });

            modelBuilder.Entity<Child>().HasData(
                new Child
                {
                    Id = 1,
                    Name = "John",
                    FamilyId = 1
                },
                new Child
                {
                    Id = 2,
                    Name = "Jane",
                    FamilyId = 1
                });

            modelBuilder.Entity<Gift>().HasData(
                new Gift
                {
                    Id = 1,
                    Name = "Doll",
                    ChildId = 1,
                    Description = "A doll"
                },
                new Gift
                {
                    Id = 2,
                    Name = "Game",
                    ChildId = 2,
                    Description = "A cool game to play with the family"
                },
                new Gift
                {
                    Id = 3, ChildId = 2, Name = "Book", Description = "A scary one"
                }
            );

            modelBuilder.Entity<Family>().HasData(
                new Family {  Id = 2, AddressId = 2, Name = "Jansen"}
                );

            modelBuilder.Entity<Child>().HasData(
               new Child { Id = 3, Name = "Piet", FamilyId = 2 },
               new Child { Id = 4, Name = "Sandra", FamilyId = 2 });

            modelBuilder.Entity<Gift>().HasData(
                new Gift { Id = 4, ChildId = 3, Name = "Bicyle", Description = "A fast one"},
                new Gift { Id = 5, ChildId = 4, Name = "Book", Description = "A real time novel"});
                
        }
    }
}
