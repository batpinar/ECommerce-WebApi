using AutoMapper;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductBrandCommands.UpdateProductBrandCommands
{
    public class UpdateProductBrandCommandHandler : IRequestHandler<UpdateProductBrandCommand, Guid>
    {
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IMapper _mapper;

        public UpdateProductBrandCommandHandler(IProductBrandRepository productBrandRepository, IMapper mapper)
        {
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateProductBrandCommand request, CancellationToken cancellationToken)
        {
            var updateProductName = await _productBrandRepository.GetByIdAsync(request.Id);
            if (updateProductName == null)
                throw new DatabaseValidationException("ProductBrand to be updated not found!");

            updateProductName.ProductBrandName = request.ProductBrandName;
            await _productBrandRepository.UpdateAsync(updateProductName);
            return request.Id;
        }
    }
}
