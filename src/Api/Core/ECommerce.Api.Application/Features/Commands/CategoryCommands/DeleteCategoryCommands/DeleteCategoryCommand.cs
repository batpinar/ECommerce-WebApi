using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.CategoryCommands.DeleteCategoryCommands
{
    public class DeleteCategoryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
