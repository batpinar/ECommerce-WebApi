using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductModelCommands.DeleteProductModelCommands
{
    public class DeleteProductModelCommandHandler : IRequestHandler<DeleteProductModelCommand, Guid>
    {
        private readonly IProductModelRepository _productModelRepository;

        public DeleteProductModelCommandHandler(IProductModelRepository productModelRepository)
        {
            _productModelRepository = productModelRepository;
        }

        public async Task<Guid> Handle(DeleteProductModelCommand request, CancellationToken cancellationToken)
        {
            var deleteProductModel = await _productModelRepository.GetByIdAsync(request.Id);

            if (deleteProductModel == null)
                throw new DatabaseValidationException("ProductModel to be deleted not found!");

            await _productModelRepository.DeleteAsync(deleteProductModel);

            return request.Id;
        }
    }
}
