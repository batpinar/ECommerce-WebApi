using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductModelCommands.UpdateProductModelCommands
{
    public class UpdateProductModelCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid CategoryID { get; set; } // Category ID (Foreign Key)
        public Guid ProductBrandID { get; set; }
        public string ProductModelName { get; set; } // Product Name
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
