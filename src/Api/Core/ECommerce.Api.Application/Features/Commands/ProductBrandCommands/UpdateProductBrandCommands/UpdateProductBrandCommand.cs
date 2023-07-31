using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductBrandCommands.UpdateProductBrandCommands
{
    public class UpdateProductBrandCommand : IRequest<Guid>
    {
        public string ProductBrandName { get; set; } 
        public Guid Id { get; set; }
    }
}
