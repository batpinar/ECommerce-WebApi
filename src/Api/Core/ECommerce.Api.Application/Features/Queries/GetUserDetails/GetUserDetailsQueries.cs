using ECommerce.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetUserDetails
{
    public class GetUserDetailsQueries : IRequest<GetUserDetailViewModel>
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public GetUserDetailsQueries(Guid userId, string userName = null)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}
