using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductModelCommands.DeleteProductModelCommands
{
    public class DeleteProductModelCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
