using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetCategories
{
    public class GetCategoriesQueriesValidator  : AbstractValidator<GetCategoriesQueries>
    {
        public GetCategoriesQueriesValidator()
        {
            RuleFor(query => query.Count).LessThanOrEqualTo(10).GreaterThan(0);
            RuleFor(query => query.CreatedById).NotEmpty();
        }
    }
}
