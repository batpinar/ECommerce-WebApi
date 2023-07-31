using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.CategoryCommands.CreateCategoryCommands
{
    public class CreateProductBrandCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateProductBrandCommandValidator()
        {
            RuleFor(command => command.CategoryName).NotNull().MinimumLength(5).MaximumLength(50);
            RuleFor(command => command.CreatedById).NotEmpty();
        }
    }
}
