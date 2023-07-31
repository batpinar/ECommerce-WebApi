using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.CategoryCommands.UpdateCategoryCommands
{
    public class UpdateProductBrandCommandValidator : AbstractValidator<UpdateProductBrandCommand>
    {
        public UpdateProductBrandCommandValidator()
        {
            RuleFor(command => command.CategoryName).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
