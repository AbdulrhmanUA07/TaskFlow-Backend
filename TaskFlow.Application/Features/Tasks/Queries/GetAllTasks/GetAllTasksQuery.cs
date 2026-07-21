using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;  
using TaskFlow.Application.DTOs.TaskDtos;

namespace TaskFlow.Application.Features.Tasks.Queries.GetAllTasks
{
    public record GetAllTasksQuery(
        TaskQueryParameters Parameters)
        : IRequest<List<TaskDto>>;

}
