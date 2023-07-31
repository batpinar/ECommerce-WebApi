using AutoMapper;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetUserDetails
{
    public class GetUserDetailsQueriesHandler : IRequestHandler<GetUserDetailsQueries, GetUserDetailViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailsQueriesHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserDetailViewModel> Handle(GetUserDetailsQueries request, CancellationToken cancellationToken)
        {
            Domain.Models.User dbUser = null;

            if (request.UserId != Guid.Empty)
                dbUser = await _userRepository.GetByIdAsync(request.UserId);
            else if (!string.IsNullOrEmpty(request.UserName))
                dbUser = await _userRepository.GetSingleAsync(i => i.UserName == request.UserName);

            return _mapper.Map<GetUserDetailViewModel>(dbUser);
        }
    }
}
