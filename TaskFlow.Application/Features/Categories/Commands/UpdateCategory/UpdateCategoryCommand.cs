using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TaskFlow.Application.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(int Id, string Name) : IRequest<bool>
    {
    }
}
