using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.TaskDtos;
using TaskFlow.Application.Features.Tasks.Commands.CreateTask;
using TaskFlow.Application.Features.Tasks.Commands.DeleteTask;
using TaskFlow.Application.Features.Tasks.Commands.UpdateTask;
using TaskFlow.Application.Features.Tasks.Queries.GetAllTasks;
using TaskFlow.Application.Features.Tasks.Queries.GetTaskById;
using TaskFlow.Domain.Common.Exceptions;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            var taskId = await _mediator.Send(command);

            return Ok(new
            {
                Id = taskId,
                Message = "Task Created Successfully"
            });
         
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TaskQueryParameters parameters)
        {
            return Ok(await _mediator.Send(
                new GetAllTasksQuery(parameters)));
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery(id));

            if (task == null)
                throw new NotFoundException("Task not found");

            return Ok(task);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }


        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTaskCommand(id));
            return NoContent();
        }




    }
}
