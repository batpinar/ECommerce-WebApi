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
    public class CategoryEntityConfiguration : BaseEntityConfiguraiton<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.ToTable("category", ECommerceDbContext.DEFAULT_SCHEMA);

            builder.HasMany(c => c.ProductBrands)
              .WithOne(pb => pb.Categories)
                .HasForeignKey(pb => pb.CategoryID);
        }
    }
}
