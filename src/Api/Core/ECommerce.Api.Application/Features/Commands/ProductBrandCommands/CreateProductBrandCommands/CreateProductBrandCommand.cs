using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductBrandCommands.CreateProductBrandCommands
{
    public class CreateProductBrandCommand : IRequest<Guid>
    {
        public Guid CategoryID { get; set; } // Category ID (Foreign Key)
        //public Guid CreatedByID { get; set; }
        public string ProductBrandName { get; set; } // Product Name

        public CreateProductBrandCommand(Guid categoryID, string productBrandName)
        {
            CategoryID = categoryID;
            ProductBrandName = productBrandName;
        }

        public CreateProductBrandCommand()
        {
            
        }
    }
}
