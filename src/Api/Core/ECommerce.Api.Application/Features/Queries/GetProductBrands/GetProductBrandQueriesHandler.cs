using AutoMapper;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Infrastructure.Extensions;
using ECommerce.Common.Models.Page;
using ECommerce.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetProductBrands
{
    public class GetProductBrandQueriesHandler : IRequestHandler<GetProductBrandQueries, PagedViewModel<GetProductBrandViewModel>>
    {
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IMapper _mapper;

        public GetProductBrandQueriesHandler(IProductBrandRepository productBrandRepository, IMapper mapper)
        {
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }

        public async Task<PagedViewModel<GetProductBrandViewModel>> Handle(GetProductBrandQueries request, CancellationToken cancellationToken)
        {
            var query = _productBrandRepository.AsQueryable();

            query = query.Where(i => i.CategoryID == request.CategoryID);

            query = query.Include(i => i.CategoryID);


            var list = query.Select(i => new GetProductBrandViewModel()
            {
                Id = i.Id,
                ProductBrandName = i.ProductBrandName,
                ProductModelCount = i.ProductModels.Count(),
            });

            //await list.ProjectTo<GetShopListViewModel>(_mapper.ConfigurationProvider)
            //   .ToListAsync(cancellationToken);

            var shopLists = await list.GetPaged(request.Page, request.PageSize);

            return shopLists;
        }
    }
}
