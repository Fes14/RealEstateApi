using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db.Entities
{
    public class CompanyDataBaseContext : DbContext
    {
        public CompanyDataBaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<RealEstateType> RealEstateTypes { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealEstate>()
                .HasOne(r => r.Type)
                .WithMany(t => t.RealEstates)
                .HasForeignKey(r => r.TypeId)
               ;

            modelBuilder.Entity<RealEstate>()
                .HasOne(r => r.Developer)
                .WithMany(d => d.RealEstates)
                .HasForeignKey(r => r.DeveloperId);

            modelBuilder.Entity<RealEstate>()
                .HasOne(r => r.Address)
                .WithOne(d => d.RealEstate)
                .HasForeignKey<RealEstate>(r => r.AddressId);


            modelBuilder.Entity<RealEstate>().HasKey(r => r.RealEstateId);
            modelBuilder.Entity<Address>().HasKey(a => a.Id);
            modelBuilder.Entity<Developer>().HasKey(a => a.DeveloperId);
            modelBuilder.Entity<RealEstateType>().HasKey(a => a.RealEstateTypeId);

            modelBuilder.Entity<Address>().HasIndex(a => new { a.City, a.Street, a.House }).IsUnique();

            modelBuilder.Entity<Address>().Property(a => a.City).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.Street).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.House).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Address>().Property(a => a.MetroStation).HasMaxLength(255);

            modelBuilder.Entity<Address>()
               .HasOne(r => r.RealEstate)
               .WithOne(d => d.Address)
               .HasForeignKey<RealEstate>(r => r.AddressId);

            modelBuilder.Entity<Address>()
        .HasData(
            new Address { Id = 1, City = "Москва", Street = "улица Поликарпова", House = "10", MetroStation = "Беговая" },
            new Address { Id = 2, City = "Москва", Street = "улица Селезнёвская", House = "21", MetroStation = "Достоевская" },
            new Address { Id = 3, City = "Москва", Street = "проспект Мира", House = "44", MetroStation = "Проспект мира" }
            );

            modelBuilder.Entity<Developer>()
         .HasData(
             new Developer { DeveloperId = 1, DeveloperName = "Быстрострой" },
             new Developer { DeveloperId = 2, DeveloperName = "10ый Этаж" }
             );

            modelBuilder.Entity<RealEstateType>()
         .HasData(
             new RealEstateType { RealEstateTypeId = 1, Name = "Коммерческая" },
             new RealEstateType { RealEstateTypeId = 2, Name = "Жилая" }
             );

            modelBuilder.Entity<RealEstate>()
            .HasData(
              new RealEstate { RealEstateId = 1, Name = "Жк Большой Дом 12", Description = "Комплекс, с закрытм довром,собсвтенным паркингом", Price = 10000000, Square = 35.5f, RoomsCount = 1, DeveloperId = 1, TypeId = 2, AddressId = 1 },
              new RealEstate { RealEstateId = 2, Name = "Жк Небо 1", Description = "Панорамный вид.", Price = 12000000, Square = 42.5f, RoomsCount = 2, DeveloperId = 1,TypeId = 2 },
              new RealEstate { RealEstateId = 3, Name = "Жк Купол", Description = "-", Price = 16000000, Square = 65.8f, RoomsCount = 3, DeveloperId = 2, TypeId = 2, AddressId = 3 }
      );
        }

    }
}
