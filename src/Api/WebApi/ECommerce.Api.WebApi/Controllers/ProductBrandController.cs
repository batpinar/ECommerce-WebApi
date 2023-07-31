using ECommerce.Api.Application.Features.Commands.CategoryCommands.DeleteCategoryCommands;
using ECommerce.Api.Application.Features.Commands.CategoryCommands.UpdateCategoryCommands;
using ECommerce.Api.Application.Features.Commands.ProductBrandCommands.CreateProductBrandCommands;
using ECommerce.Api.Application.Features.Commands.ProductBrandCommands.DeleteProductBrandCommands;
using ECommerce.Api.Application.Features.Commands.ProductBrandCommands.UpdateProductBrandCommands;
using ECommerce.Api.Application.Features.Queries.GetProductBrands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.WebApi.Controllers
{
    public class ProductBrandController : BaseController
    {
        private IMediator _mediator;

        public ProductBrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]

        //public async Task<IActionResult> GetAllProductBrand([FromQuery] GetAllProductBrandsQueries queries)
        //{
        //    var productBrand = await _mediator.Send(queries);

        //    return Ok(productBrand);
        //}

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdFromUser([FromQuery] GetProductBrandQueries query)
        {
            var shopLists = await _mediator.Send(query);
            return Ok(shopLists);
        }

        //[HttpGet]
        //[Route("GetProductBrandById")]
        //public async Task<IActionResult> GetByIdFromProductBrands(Guid shopListId, int page = 1, int pageSize = 5)
        //{
        //    var shopList = await _mediator.Send(new GetProductBrandItemsQuery(shopListId, page, pageSize));
        //    return Ok(shopList);
        //}

        //[HttpGet]
        //[Route("UserProductBrand")]
        //public async Task<IActionResult> GetUserProductBrand(Guid userId, int page, int pageSize, string userName)
        //{

        //    var productBrand = await _mediator.Send(new GetUserProductBrandQueries(userId, page, pageSize, userName));
        //    return Ok(productBrand);
        //}


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProductBrand([FromBody] CreateProductBrandCommand command)
        {
            //if (!command.CreatedById.HasValue)
            //    command.CreatedById = UserId;

            var guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteProductBrand([FromBody] DeleteProductBrandCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateProductBrand([FromBody] UpdateProductBrandCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }
    }
}
