using AutoMapper;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.CategoryCommands.UpdateCategoryCommands
{
    public class UpdateProductBrandCommandHandler : IRequestHandler<UpdateProductBrandCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductBrandCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateProductBrandCommand request, CancellationToken cancellationToken)
        {
            var updateCategory = await _categoryRepository.GetByIdAsync(request.Id);
            if (updateCategory == null)
                throw new DatabaseValidationException("Category to be updated not found!");

            updateCategory.CategoryName = request.CategoryName;
            await _categoryRepository.UpdateAsync(updateCategory);
            return request.Id;
        }
    }
}
