using AutoMapper;
using ECommerce.Api.Application.Features.Commands.CategoryCommands.CreateCategoryCommands;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Api.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductBrandCommands.CreateProductBrandCommands
{
    public class CreateProductBrandCommandHandler : IRequestHandler<CreateProductBrandCommand, Guid>
    {
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IMapper _mapper;

        public CreateProductBrandCommandHandler(IProductBrandRepository productBrandRepository, IMapper mapper)
        {
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateProductBrandCommand request, CancellationToken cancellationToken)
        {
            var dbProductBrand = _mapper.Map<ProductBrand>(request);

            await _productBrandRepository.AddAsync(dbProductBrand);
            return dbProductBrand.Id;
        }
    }
}
