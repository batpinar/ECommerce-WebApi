using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetUserDetails
{
    public class GetUserDetailsQueriesValidator : AbstractValidator<GetUserDetailsQueries>
    {
        public GetUserDetailsQueriesValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.UserName).MinimumLength(3);
        }
    }
}
