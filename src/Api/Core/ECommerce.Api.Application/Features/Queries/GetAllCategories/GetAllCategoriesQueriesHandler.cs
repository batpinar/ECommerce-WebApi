using AutoMapper;
using AutoMapper.QueryableExtensions;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Queries.GetAllCategories
{
    public class GetAllCategoriesQueriesHandler : IRequestHandler<GetAllCategoriesQueries, List<GetAllCategoryViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoryViewModel>> Handle(GetAllCategoriesQueries request, CancellationToken cancellationToken)
        {
            var query = _categoryRepository.AsQueryable();

            query = query.Where(i => i.CreatedDate < DateTime.Now.Date)
                         .Where(i => i.CreatedDate > DateTime.Now.AddMonths(-2));

            query.Include(i => i.ProductBrands)
                 .OrderBy(i => i.ProductBrands.Count)
                 .Take(request.Count);

            query.Include(i => i.ProductModels)
                 .OrderBy(i => i.ProductModels.Count)
                 .Take(request.Count);

            return await query.ProjectTo<GetAllCategoryViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
