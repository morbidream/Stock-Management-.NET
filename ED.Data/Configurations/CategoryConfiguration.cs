using ED.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Data.Configurations
{
    public class CategoryConfiguration : 
        IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> 
            builder)
        {
            builder
                .ToTable("MyCategories");

            builder
                .HasKey(c => c.CategoryId);

            builder
                .Property(c => c.Name)
                .HasMaxLength(50).IsRequired()
                .HasColumnType("varchar")
                .HasDefaultValue("name");
        }
    }
}
