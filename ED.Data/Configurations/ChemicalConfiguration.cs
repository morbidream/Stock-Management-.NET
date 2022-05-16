using ED.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Data.Configurations
{
    public class ChemicalConfiguration : IEntityTypeConfiguration<Chemical>
    {
        public void Configure(EntityTypeBuilder<Chemical> builder)
        {
            builder.OwnsOne(c => c.Address, myAddress=> {
                myAddress.Property(a => a.City)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("MyCity");
                myAddress.Property(c => c.StreetAddress)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("MyStreet");
            });
        }
    }
}
