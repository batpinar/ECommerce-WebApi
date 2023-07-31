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
    public class ProductModelEntityConfiguraiton : BaseEntityConfiguraiton<ProductModel>
    {
        public override void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            base.Configure(builder);

            builder.ToTable("productmodel", ECommerceDbContext.DEFAULT_SCHEMA);

            //builder.HasOne(x => x.ProductBrands)
            //    .WithMany(x => x.ProductModels)
            //    .HasForeignKey(x => x.ProductBrandID);
        }
    }
}
