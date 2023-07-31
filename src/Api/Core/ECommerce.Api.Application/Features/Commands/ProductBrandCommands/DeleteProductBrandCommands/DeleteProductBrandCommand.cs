using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductBrandCommands.DeleteProductBrandCommands;
    public class DeleteProductBrandCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }

