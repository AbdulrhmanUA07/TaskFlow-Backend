using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TaskFlow.Application.Features.Tasks.Commands.CreateTask;

namespace TaskFlow.Application.Features.Tasks.Validators
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator() {

            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);

           RuleFor(x => x.Description).MaximumLength(1000);

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);

            RuleFor(x => x.DueDate).GreaterThan(DateTime.UtcNow)
                .WithMessage("Due Date must be in the future.");


        }

    }
}
