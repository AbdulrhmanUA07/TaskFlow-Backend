using MediatR;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Common.Exceptions;
using TaskFlow.Domain.Entities;     
using TaskFlow.Domain.Enums;



namespace TaskFlow.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly INotificationService _notificationService;
        public UpdateTaskHandler(ITaskRepository taskRepository , ICategoryRepository categoryRepository 
            , ICurrentUserService currentUser , INotificationService notificationService)
        {
            _taskRepository = taskRepository;
            _categoryRepository = categoryRepository;
            _currentUser = currentUser;
            _notificationService = notificationService;
        }

        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync( request.Id,_currentUser.UserId!);

            if (task == null)
                throw new NotFoundException("Task not found");

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
                throw new NotFoundException("Category not found");

            task.Title = request.Title;
            task.Description = request.Description;
            task.Priority = (TaskPriority)request.Priority;
            task.Status = (TaskStats)request.Status;
            task.DueDate = request.DueDate;
            task.CategoryId = request.CategoryId;

            await _taskRepository.UpdateAsync(task);
            await _notificationService.TaskUpdated(task.Title);


        }
    }
}

