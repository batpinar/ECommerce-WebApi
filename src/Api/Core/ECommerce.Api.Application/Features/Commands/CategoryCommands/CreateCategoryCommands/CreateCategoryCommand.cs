using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.CategoryCommands.CreateCategoryCommands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string CategoryName { get; set; } // Category Name
        public Guid CreatedById { get; set; }

        public CreateCategoryCommand(string categoryName, Guid createdById)
        {
            CategoryName = categoryName;
            CreatedById = createdById;
        }
        public CreateCategoryCommand()
        {
            
        }
    }
}
