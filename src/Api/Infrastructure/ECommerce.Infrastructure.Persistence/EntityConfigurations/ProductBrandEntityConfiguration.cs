using ECommerce.Api.Domain.Models;
using ECommerce.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Persistence.EntityConfigurations
{
    public class ProductBrandEntityConfiguration : BaseEntityConfiguraiton<ProductBrand>
    {
        public override void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            base.Configure(builder);

            builder.ToTable("productbrand", ECommerceDbContext.DEFAULT_SCHEMA);

            // Primary key configuration for ProductBrand entity
            builder.HasKey(pb => pb.Id);

            // Foreign key relationship with Category entity
            builder.HasOne(pb => pb.Categories)
                   .WithMany(c => c.ProductBrands)
                   .HasForeignKey(pb => pb.CategoryID);

            //builder.HasOne(pb => pb.CreatedBy)
            //    .WithMany()
            //    .HasForeignKey(pb => pb.CreatedByID)
            //    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
