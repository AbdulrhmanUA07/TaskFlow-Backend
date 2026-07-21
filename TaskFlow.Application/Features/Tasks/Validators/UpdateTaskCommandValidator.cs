using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TaskFlow.Application.Features.Tasks.Commands.UpdateTask;

namespace TaskFlow.Application.Features.Tasks.Validators
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {

            RuleFor(x => x.Title)
             .NotEmpty()
             .MaximumLength(200);

            RuleFor(x => x.Description)
                .MaximumLength(1000);

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);

        }
    }

}