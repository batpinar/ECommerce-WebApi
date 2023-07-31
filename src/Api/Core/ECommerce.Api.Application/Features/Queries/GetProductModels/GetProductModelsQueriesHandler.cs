using AutoMapper;
using ECommerce.Api.Application.Features.Queries.GetProductBrands;
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

namespace ECommerce.Api.Application.Features.Queries.GetProductModels
{
    public class GetProductModelsQueriesHandler : IRequestHandler<GetProductModelsQueries, PagedViewModel<GetProductModelViewModel>>
    {
        private readonly IProductModelRepository _productModelRepository;
        private readonly IMapper _mapper;

        public GetProductModelsQueriesHandler(IProductModelRepository productModelRepository, IMapper mapper)
        {
            _productModelRepository = productModelRepository;
            _mapper = mapper;
        }

        public async Task<PagedViewModel<GetProductModelViewModel>> Handle(GetProductModelsQueries request, CancellationToken cancellationToken)
        {
            var query = _productModelRepository.AsQueryable();

            query = query.Where(i => i.ProductBrandID == request.ProductBrandID);

            query = query.Include(i => i.ProductBrandID);


            var list = query.Select(i => new GetProductModelViewModel()
            {
                Id = i.Id,
                ProductBrandID = i.ProductBrandID,
                ProductModelName = i.ProductModelName,
                Price = i.Price,
                CategoryID = i.CategoryID,
                Count = i.Count,
                Description = i.Description,
            });

            //await list.ProjectTo<GetShopListViewModel>(_mapper.ConfigurationProvider)
            //   .ToListAsync(cancellationToken);

            var shopLists = await list.GetPaged(request.Page, request.PageSize);

            return shopLists;
        }
    }
}
