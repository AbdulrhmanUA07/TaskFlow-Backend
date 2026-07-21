using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Features.Categories.Commands.CreateCategory;
using TaskFlow.Application.Features.Categories.Commands.DeleteCategory;
using TaskFlow.Application.Features.Categories.Commands.UpdateCategory;
using TaskFlow.Application.Features.Categories.Queries.GetAllCategories;
using TaskFlow.Application.Features.Categories.Queries.GetCategoryById;
using TaskFlow.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(new
            {
                Id = id,
                Message = "Category Created Successfully"
            });
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));

            if (category is null)
                throw new NotFoundException("Category not found");

            return Ok(category);
        }



        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id));

            return NoContent();
        }





    }
       
}
