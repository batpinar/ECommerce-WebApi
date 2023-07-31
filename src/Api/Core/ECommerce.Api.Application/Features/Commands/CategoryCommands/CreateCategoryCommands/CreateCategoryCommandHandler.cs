using AutoMapper;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Api.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.CategoryCommands.CreateCategoryCommands
{
    public class CreateProductBrandCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateProductBrandCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var dbCategory = _mapper.Map<Category>(request);
            
            await _categoryRepository.AddAsync(dbCategory);
            return dbCategory.Id;
        }
    }
}
