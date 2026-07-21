using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;  
using TaskFlow.Application.DTOs.TaskDtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Features.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery , List<TaskDto >>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICurrentUserService _currentUser;
        public GetAllTasksHandler(ITaskRepository taskRepository , ICurrentUserService currentUser)
        {
            _taskRepository = taskRepository;
            _currentUser = currentUser;
        }
        public async Task<List<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync( _currentUser.UserId!, request.Parameters);
            return tasks.Select(task => new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority.ToString(),
                Status = task.Status.ToString(),
                DueDate = task.DueDate,
                Category = task.Category.Name
            }).ToList();
        }



    }
}
