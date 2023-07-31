using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.CategoryCommands.DeleteCategoryCommands
{
    public class DeleteProductBrandCommandValidator : AbstractValidator<DeleteProductBrandCommand>
    {
        public DeleteProductBrandCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
