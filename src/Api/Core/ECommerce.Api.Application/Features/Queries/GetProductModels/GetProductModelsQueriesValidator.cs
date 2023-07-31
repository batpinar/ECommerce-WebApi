using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetProductModels
{
    public class GetProductModelsQueriesValidator : AbstractValidator<GetProductModelsQueries>
    {
        public GetProductModelsQueriesValidator()
        {
            RuleFor(query => query.CategoryID).NotEmpty();
            RuleFor(query => query.ProductBrandID).NotEmpty();
        }
    }
}
