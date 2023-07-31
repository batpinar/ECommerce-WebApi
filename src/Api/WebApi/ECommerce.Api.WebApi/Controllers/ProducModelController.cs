using ECommerce.Api.Application.Features.Commands.ProductBrandCommands.CreateProductBrandCommands;
using ECommerce.Api.Application.Features.Commands.ProductModelCommands.CreateProductModelCommands;
using ECommerce.Api.Application.Features.Commands.ProductModelCommands.DeleteProductModelCommands;
using ECommerce.Api.Application.Features.Commands.ProductModelCommands.UpdateProductModelCommands;
using ECommerce.Api.Application.Features.Queries.GetProductModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.WebApi.Controllers
{
    public class ProducModelController : BaseController
    {
        private IMediator _mediator;

        public ProducModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]

        //public async Task<IActionResult> GetAllProductMode([FromQuery] GetAllProductModelsQueries queries)
        //{
        //    var shopLists = await _mediator.Send(queries);

        //    return Ok(shopLists);
        //}

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdFromUser([FromQuery] GetProductModelsQueries query)
        {
            var shopLists = await _mediator.Send(query);
            return Ok(shopLists);
        }

        [HttpGet]
        [Route("GetProductModelById")]
        public async Task<IActionResult> GetByIdFromProductModels(Guid productModelId, Guid? categoryID, int page = 1, int pageSize = 5)
        {
            var shopList = await _mediator.Send(new GetProductModelsQueries(productModelId, categoryID, page, pageSize));
            return Ok(shopList);
        }

        //[HttpGet]
        //[Route("UserProductModel")]
        //public async Task<IActionResult> GetUserProductModels(Guid userId, int page, int pageSize, string userName)
        //{

        //    var shopList = await _mediator.Send(new GetUserProductModelQueries(userId, page, pageSize, userName));
        //    return Ok(shopList);
        //}


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProductModel([FromBody] CreateProductModelCommand command)
        {
            //if (!command.CreatedById.HasValue)
            //    command.CreatedById = UserId;

            var guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteProductModel([FromBody] DeleteProductModelCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateProductModel([FromBody] UpdateProductModelCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }
    }
}
