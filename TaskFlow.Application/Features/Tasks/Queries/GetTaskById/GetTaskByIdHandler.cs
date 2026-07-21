using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;  
using TaskFlow.Application.DTOs.TaskDtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Features.Tasks.Queries.GetTaskById
{
     public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskDto?>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICurrentUserService _currentUser;
        public GetTaskByIdHandler(ITaskRepository taskRepository , ICurrentUserService currentUser)
        {
            _taskRepository = taskRepository;
            _currentUser = currentUser;
        }

        public async Task<TaskDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync( request.Id , _currentUser.UserId!);

            if (task == null)
            {
                return null;
            }

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority.ToString(),
                Status = task.Status.ToString(),
                DueDate = task.DueDate,
                Category = task.Category.Name
            };
        }
    }
}
