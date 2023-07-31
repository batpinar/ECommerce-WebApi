using ECommerce.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Persistence.EntityConfigurations
{
    public class ShoppingOrderEntityConfiguration : BaseEntityConfiguraiton<ShoppingOrder>
    {
        public override void Configure(EntityTypeBuilder<ShoppingOrder> builder)
        {
            base.Configure(builder);
        }
    }
}
