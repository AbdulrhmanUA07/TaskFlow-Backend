using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TaskFlow.Application.DTOs.TaskDtos;


namespace TaskFlow.Application.Features.Tasks.Queries.GetTaskById
{
    public record GetTaskByIdQuery(int Id) : IRequest<TaskDto?>
    {
    }
}
