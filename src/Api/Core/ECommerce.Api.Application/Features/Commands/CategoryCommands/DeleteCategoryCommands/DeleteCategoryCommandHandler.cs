using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.CategoryCommands.DeleteCategoryCommands
{
    public class DeleteProductBrandCommandHandler :IRequestHandler<DeleteProductBrandCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteProductBrandCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(DeleteProductBrandCommand request, CancellationToken cancellationToken)
        {
            var deleteCategory = await _categoryRepository.GetByIdAsync(request.Id);

            if (deleteCategory == null)
                throw new DatabaseValidationException("Category to be deleted not found!");

            await _categoryRepository.DeleteAsync(deleteCategory);

            return request.Id;
        }
    }
}
