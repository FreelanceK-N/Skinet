using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Id).IsRequired();
            builder.Property(product => product.Name).IsRequired().HasMaxLength(100);
            builder.Property(product => product.Description).IsRequired();
            builder.Property(product => product.PictureUrl).IsRequired();
            builder.HasOne(brand => brand.ProductBrand).WithMany().HasForeignKey(product => product.ProductBrandId);
            builder.HasOne(type => type.ProductType).WithMany().HasForeignKey(product => product.ProductTypeId);

        }
    }
}