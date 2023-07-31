using AutoMapper;
using ECommerce.Api.Application.Interfaces.Repositories;
using ECommerce.Api.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Features.Commands.ProductModelCommands.CreateProductModelCommands
{
    public class CreateProductModelCommandHandler : IRequestHandler<CreateProductModelCommand, Guid>
    {
        private readonly IProductModelRepository _productModelRepository;
        private readonly IMapper _mapper;

        public CreateProductModelCommandHandler(IProductModelRepository productModelRepository, IMapper mapper)
        {
            _productModelRepository = productModelRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateProductModelCommand request, CancellationToken cancellationToken)
        {
            var dbProductModel = _mapper.Map<ProductModel>(request);

            await _productModelRepository.AddAsync(dbProductModel);
            return dbProductModel.Id;
        }
    }
}
