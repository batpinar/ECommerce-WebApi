using AutoMapper;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Api.Domain.Models;
using ECommerce.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductModelCommands.UpdateProductModelCommands
{
    public class UpdateProductModelCommandHandler : IRequestHandler<UpdateProductModelCommand, Guid>
    {
        private readonly IProductModelRepository _productModelRepository;
        private readonly IMapper _mapper;

        public UpdateProductModelCommandHandler(IProductModelRepository productModelRepository, IMapper mapper)
        {
            _productModelRepository = productModelRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateProductModelCommand request, CancellationToken cancellationToken)
        {
            var updateProductModel = await _productModelRepository.GetByIdAsync(request.Id);

            if (updateProductModel == null)
                throw new DatabaseValidationException("ProductModel to be updated not found!");

            updateProductModel.Description = request.Description;
            updateProductModel.CategoryID = request.CategoryID;
            updateProductModel.ProductModelName = request.ProductModelName;
            updateProductModel.ProductBrandID = request.ProductBrandID;
            updateProductModel.Price = request.Price;
            updateProductModel.Count = request.Count;

            await _productModelRepository.UpdateAsync(updateProductModel);

            return request.Id;

        }
    }
}
