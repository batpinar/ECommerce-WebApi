using AutoMapper;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Events.UserEvent;
using ECommerce.Common.Infrastructure.Exceptions;
using ECommerce.Common.Infrastructure;
using ECommerce.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Common;

namespace ECommerce.Api.Application.Features.Commands.UserCommands.UpdateUserCommands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetByIdAsync(request.Id);

            if (dbUser == null)
                throw new DatabaseValidationException("User not found!");

            var dbUserEmailAddress = dbUser.EmailAddress;
            var emailChanged = string.CompareOrdinal(request.EmailAddress, dbUserEmailAddress) != 0;
            _mapper.Map(request, dbUser);

            var rows = await _userRepository.UpdateAsync(dbUser);

            //Check if email changed

            if (emailChanged && rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = dbUserEmailAddress,
                    NewEmailAddress = request.EmailAddress
                };
                QueueFactory.SendMessageToExchange(exchageName: ECommerceConstants.UserExchangeName,
                                                   exchangeType: ECommerceConstants.DefaultExchangeType,
                                                   queueName: ECommerceConstants.UserEmailChangeQueueName,
                                                   obj: @event);

                dbUser.EmailConfirmed = false;
                await _userRepository.UpdateAsync(dbUser);
            }


            return dbUser.Id;
        }
    }
}
