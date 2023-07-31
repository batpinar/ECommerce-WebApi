using ECommerce.Api.Domain.Models;
using ECommerce.Common.Models.Page;
using ECommerce.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetProductModels
{
    public class GetProductModelsQueries : BasePagedQuery, IRequest<PagedViewModel<GetProductModelViewModel>>
    {
        public GetProductModelsQueries(Guid? productBrandId, Guid? categoryID, int page, int pageSize) : base(page, pageSize)
        {
            ProductBrandID = productBrandId;

            CategoryID = categoryID;
        }

        public Guid? CategoryID { get; set; }
        public Guid? ProductBrandID { get; set; }
    }
}
