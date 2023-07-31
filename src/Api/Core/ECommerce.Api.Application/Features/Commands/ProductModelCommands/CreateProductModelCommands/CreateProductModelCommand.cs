using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductModelCommands.CreateProductModelCommands
{
    public class CreateProductModelCommand : IRequest<Guid>
    {
        public Guid CategoryID { get; set; } // Category ID (Foreign Key)
        public Guid ProductBrandID { get; set; }
        public string ProductModelName { get; set; } // Product Name
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public CreateProductModelCommand(Guid categoryID, Guid productBrandID, string productModelName, string description, decimal price, int count)
        {
            CategoryID = categoryID;
            ProductBrandID = productBrandID;
            ProductModelName = productModelName;
            Description = description;
            Price = price;
            Count = count;
        }

        public CreateProductModelCommand()
        {

        }
    }
}
