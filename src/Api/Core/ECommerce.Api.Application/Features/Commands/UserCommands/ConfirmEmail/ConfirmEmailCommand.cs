using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.UserCommands.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public Guid ComfirmId { get; set; }
    }

    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailConfirmationRepository _confirmationRepository;

        public ConfirmEmailCommandHandler(IUserRepository userRepository, IEmailConfirmationRepository confirmationRepository)
        {
            _userRepository = userRepository;
            _confirmationRepository = confirmationRepository;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confirmation = await _confirmationRepository.GetByIdAsync(request.ComfirmId);

            if (confirmation is null)
                throw new DatabaseValidationException("Confirmation not found!");

            var dbUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == confirmation.NewEmailAddress);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found with this email!");

            if (dbUser.EmailConfirmed)
                throw new DatabaseValidationException("Email address is already confirmed");
            dbUser.EmailConfirmed = true;
            await _userRepository.UpdateAsync(dbUser);

            return true;
        }
    }
}
