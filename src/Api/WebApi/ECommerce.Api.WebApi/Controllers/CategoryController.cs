using ECommerce.Api.Application.Features.Commands.CategoryCommands.CreateCategoryCommands;
using ECommerce.Api.Application.Features.Commands.CategoryCommands.DeleteCategoryCommands;
using ECommerce.Api.Application.Features.Commands.CategoryCommands.UpdateCategoryCommands;
using ECommerce.Api.Application.Features.Queries.GetAllCategories;
using ECommerce.Api.Application.Features.Queries.GetCategories;
using ECommerce.Api.Application.Features.Queries.GetProductBrands;
using ECommerce.Api.Application.Features.Queries.GetProductModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.WebApi.Controllers
{
    public class CategoryController : BaseController
    {
        private IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoriesQueries queries)
        {
            var shopLists = await _mediator.Send(queries);

            return Ok(shopLists);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdFromUser([FromQuery] GetCategoriesQueries query)
        {
            var shopLists = await _mediator.Send(query);
            return Ok(shopLists);
        }

        [HttpGet]
        [Route("GetShopListById")]
        public async Task<IActionResult> GetByIdFromCategories(Guid productBrandId, Guid categoryID, int page = 1, int pageSize = 5)
        {
            var shopList = await _mediator.Send(new GetProductBrandQueries(productBrandId, categoryID, page, pageSize));
            return Ok(shopList);
        }

        [HttpGet]
        [Route("ProductModel")]
        public async Task<IActionResult> GetUserCategory(Guid productBrandId, int page, int pageSize, Guid categoryID)
        {

            var shopList = await _mediator.Send(new GetProductModelsQueries(productBrandId, categoryID, pageSize,  page));
            return Ok(shopList);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            //if (!command.CreatedById.HasValue)
            //    command.CreatedById = UserId;

            var guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }
    }
}
