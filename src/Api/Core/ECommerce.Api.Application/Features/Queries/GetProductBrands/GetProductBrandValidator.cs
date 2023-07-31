using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetProductBrands
{
    public class GetProductBrandValidator : AbstractValidator<GetProductBrandQueries>
    {
        public GetProductBrandValidator()
        {
            RuleFor(query => query.CategoryID).NotEmpty();
            RuleFor(query => query.ProductBrandId).NotEmpty();
        }
    }
}
