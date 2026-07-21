using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TaskFlow.Application.Features.Tasks.Commands.CreateTask
{
   public record CreateTaskCommand( string Title,string? Description, int Priority,int Status, DateTime DueDate, int CategoryId) : IRequest<int>;

}
