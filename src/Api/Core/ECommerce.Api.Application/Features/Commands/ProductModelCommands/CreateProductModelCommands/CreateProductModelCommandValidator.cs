using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductModelCommands.CreateProductModelCommands
{
    public class CreateProductModelCommandValidator : AbstractValidator<CreateProductModelCommand>
    {
        public CreateProductModelCommandValidator()
        {
            RuleFor(command => command.ProductModelName).NotNull().MaximumLength(500);
            RuleFor(command => command.Description).MaximumLength(500);
            RuleFor(command => command.ProductBrandID).NotNull();
            RuleFor(command => command.Count).GreaterThan(0).NotNull(); ;
            RuleFor(command => command.CategoryID).NotNull();
            RuleFor(command => command.Price).GreaterThan(0).NotNull();
        }
    }
}
