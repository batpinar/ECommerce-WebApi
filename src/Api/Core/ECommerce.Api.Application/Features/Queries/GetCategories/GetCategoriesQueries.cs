using ECommerce.Common.Models.Page;
using ECommerce.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetCategories
{
    public class GetCategoriesQueries : IRequest<List<GetCategoryViewModel>>
    {
        public int Count { get; set; } = 10;
        public Guid CreatedById { get; set; }
    }
}
