using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductModelCommands.DeleteProductModelCommands
{
    public class DeleteProductModelCommandsValidator : AbstractValidator<DeleteProductModelCommand>
    {
        public DeleteProductModelCommandsValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
