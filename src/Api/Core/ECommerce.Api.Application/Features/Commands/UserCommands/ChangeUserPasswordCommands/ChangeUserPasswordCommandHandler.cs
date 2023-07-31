using AutoMapper;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Events.UserEvent;
using ECommerce.Common.Infrastructure.Exceptions;
using ECommerce.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.UserCommands.ChangeUserPasswordCommands
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue)
                throw new ArgumentNullException(nameof(request.UserId));

            var dbUser = await _userRepository.GetByIdAsync(request.UserId.Value);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found!");

            var encryptOldPass = PasswordEncryptor.Encrypt(request.OldPassword);

            if (dbUser.Password != encryptOldPass)
                throw new DatabaseValidationException("Old password wrong!");

            var encryptNewPass = PasswordEncryptor.Encrypt(request.NewPassword);

            if (dbUser.Password == encryptNewPass)
                throw new DatabaseValidationException("You should not use old password as a new password");

            dbUser.Password = encryptNewPass;

            await _userRepository.UpdateAsync(dbUser);

            return true;
        }
    }
}
