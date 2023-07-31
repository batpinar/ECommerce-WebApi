using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.CategoryCommands.UpdateCategoryCommands
{
    public class UpdateCategoryCommand : IRequest<Guid>
    {
        public string CategoryName { get; set; } // Category Name
        public Guid Id { get; set; }
    }
}
