using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;  

namespace TaskFlow.Application.Features.Tasks.Commands.DeleteTask;

   public record DeleteTaskCommand(int Id) : IRequest;
    

