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
    public class UserEntityConfiguration : BaseEntityConfiguraiton<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user", ECommerceDbContext.DEFAULT_SCHEMA);

            //builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName).HasMaxLength(255).IsRequired(true);
            builder.Property(u => u.LastName).HasMaxLength(255).IsRequired(true);
            builder.Property(u => u.UserName).HasMaxLength(100).IsRequired(true);
            builder.Property(u => u.EmailAddress).HasMaxLength(255).IsRequired(true);
            builder.Property(u => u.PhoneNumer).IsRequired(true);
            builder.Property(u => u.IdentityNumber).IsRequired(true);
            builder.Property(u => u.Password).HasMaxLength(255).IsRequired(true);
            builder.Property(u => u.EmailConfirmed).IsRequired(true);
            builder.Property(u => u.Address).HasMaxLength(1000).IsRequired(false);
        }

    }
}
