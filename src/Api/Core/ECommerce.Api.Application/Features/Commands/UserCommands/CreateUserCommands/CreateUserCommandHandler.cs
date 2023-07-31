using AutoMapper;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common;
using ECommerce.Common.Events.UserEvent;
using ECommerce.Common.Infrastructure;
using ECommerce.Common.Infrastructure.Exceptions;
using ECommerce.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.UserCommands.CreateUserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.GetSingleAsync(x => x.EmailAddress == request.EmailAddress);

            if (existUser is not null)
                throw new DatabaseValidationException("This user already created!");

            var dbUser = _mapper.Map<Domain.Models.User>(request);

            var rows = await _userRepository.AddAsync(dbUser);

            if(rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAddress
                };
                QueueFactory.SendMessageToExchange(exchageName: ECommerceConstants.UserExchangeName,
                                                   exchangeType: ECommerceConstants.DefaultExchangeType,
                                                   queueName: ECommerceConstants.UserEmailChangeQueueName,
                                                   obj: @event);
            }
            return dbUser.Id;


        }
    }
}
