using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ED.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>

    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.HasDiscriminator<int>("IsBiological")
            //    .HasValue<Product>(0)
            //    .HasValue<Chemical>(2)
            //    .HasValue<Biological>(1);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);//activer la supression en cascade
            builder.HasMany(p => p.Providers)
                .WithMany(p => p.Products)
                .UsingEntity(j=>j.ToTable("Providings"));

           builder.HasMany(p => p.Clients)
                .WithMany(c => c.Products)
                .UsingEntity<Facture>(
                     j => j.HasOne(f => f.Client).WithMany(c => c.Factures)
                      .HasForeignKey(f => f.ClientFk),
                     j => j.HasOne(f => f.Product).WithMany(c => c.Factures)
                      .HasForeignKey(f => f.ProductFk),
                     j=> j.HasKey(f=>new { f.ClientFk, f.ProductFk,f.DateAchat })
                 );
        }
    }
}
