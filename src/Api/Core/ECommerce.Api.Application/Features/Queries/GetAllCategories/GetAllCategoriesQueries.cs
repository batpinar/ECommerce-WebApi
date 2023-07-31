using ECommerce.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetAllCategories
{
    public class GetAllCategoriesQueries : IRequest<List<GetAllCategoryViewModel>>
    {
        public int Count { get; set; }
    }
}
