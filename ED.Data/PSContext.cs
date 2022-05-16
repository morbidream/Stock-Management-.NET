using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ED.Domain;
using ED.Data.Configurations;
using System.Linq;

namespace ED.Data
{
    public class PSContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<Biological> Biologicals { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source = (localdb)\MSSQLLOCALDB ; Initial Catalog = ProductStoreTWIN4 ; integrated security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasDiscriminator<int>("IsBiological")
            //    .HasValue<Product>(0)
            //    .HasValue<Chemical>(2)
            //    .HasValue<Biological>(1);

            modelBuilder.Entity<Chemical>().ToTable("Chemicals");
            modelBuilder.Entity<Biological>().ToTable("Biologicals");

            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.ClrType == typeof(String) && p.Name.StartsWith("Name"));
            
            foreach (var item in properties)
            {
                item.SetColumnName("MyName");
            }
            //modelBuilder
            //    .Entity<Facture>()
            //    .HasKey(f => new { f.ClientFk, f.ProductFk, f.DateAchat });

            //modelBuilder.Entity<Facture>()
            //    .HasOne(f => f.Client)
            //    .WithMany(c => c.Factures)
            //    .HasForeignKey(f => f.ClientFk);

            //modelBuilder.Entity<Facture>()
            //   .HasOne(f => f.Product)
            //   .WithMany(c => c.Factures)
            //   .HasForeignKey(f => f.ProductFk);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ChemicalConfiguration());
        }
        //public PSContext()
        //{
        //    Database.EnsureCreated();
        //}
    }
}
