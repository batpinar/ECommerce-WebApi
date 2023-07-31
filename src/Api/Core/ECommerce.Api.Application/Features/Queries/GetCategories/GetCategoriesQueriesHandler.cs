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

namespace ECommerce.Api.Application.Features.Queries.GetCategories
{
    public class GetCategoriesQueriesHandler : IRequestHandler<GetCategoriesQueries, List<GetCategoryViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryViewModel>> Handle(GetCategoriesQueries request, CancellationToken cancellationToken)
        {
            var query = _categoryRepository.AsQueryable();

            query = query.Where(i => i.CreatedById == request.CreatedById);


            query = query.Include(i => i.ProductBrands)
                         .OrderByDescending(i => i.CreatedDate)
                         .Take(request.Count);
            query = query.Include(i => i.ProductModels)
                         .OrderByDescending(i => i.CreatedDate)
                         .Take(request.Count);

            return await query.ProjectTo<GetCategoryViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
