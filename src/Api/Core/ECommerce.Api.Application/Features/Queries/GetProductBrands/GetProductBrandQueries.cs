using ECommerce.Api.Domain.Models;
using ECommerce.Common.Models.Page;
using ECommerce.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetProductBrands
{

    public class GetProductBrandQueries : BasePagedQuery, IRequest<PagedViewModel<GetProductBrandViewModel>>
    {
        public GetProductBrandQueries(Guid? productBrandId, Guid? categoryID, int page, int pageSize) : base(page, pageSize)
        {
            ProductBrandId = productBrandId;

            CategoryID = categoryID;
        }

        public Guid? ProductBrandId { get; set; }
        public Guid? CategoryID { get; set; }
    }

}
