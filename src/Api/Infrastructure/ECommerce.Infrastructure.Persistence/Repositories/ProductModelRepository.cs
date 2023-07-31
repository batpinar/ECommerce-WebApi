using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Api.Domain.Models;
using ECommerce.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Persistence.Repositories
{
    public class ProductModelRepository : GenericRepository<ProductModel>, IProductModelRepository
    {
        public ProductModelRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
