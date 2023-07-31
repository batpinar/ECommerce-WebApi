using ECommerce.Api.Application.Features.Commands.ProductBrandCommands.CreateProductBrandCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductBrandCommands.CreateCategoryCommands
{
    public class CreateProductBrandCommandValidator : AbstractValidator<CreateProductBrandCommand>
    {
        public CreateProductBrandCommandValidator()
        {
            RuleFor(command => command.ProductBrandName).NotNull().MinimumLength(5).MaximumLength(200);
            RuleFor(command => command.CategoryID).NotEmpty();
        }
    }
}
