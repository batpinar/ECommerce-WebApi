using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductBrandCommands.DeleteProductBrandCommands
{
    public class DeleteProductBrandCommandHandler :IRequestHandler<DeleteProductBrandCommand, Guid>
    {
    private readonly IProductBrandRepository _productBrandRepository;

    public DeleteProductBrandCommandHandler(IProductBrandRepository productBrandRepository)
    {
        _productBrandRepository = productBrandRepository;
    }

    public async Task<Guid> Handle(DeleteProductBrandCommand request, CancellationToken cancellationToken)
        {
            var deleteProductBrand = await _productBrandRepository.GetByIdAsync(request.Id);

            if (deleteProductBrand == null)
                throw new DatabaseValidationException("ProductBrand to be deleted not found!");

            await _productBrandRepository.DeleteAsync(deleteProductBrand);

            return request.Id;
        }
    }
}
