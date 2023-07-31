using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductBrandCommands.UpdateProductBrandCommands
{
    public class UpdateProductBrandCommandValidator : AbstractValidator<UpdateProductBrandCommand>
    {
        public UpdateProductBrandCommandValidator()
        {
            RuleFor(command => command.ProductBrandName).NotEmpty().MinimumLength(5).MaximumLength(200);
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
