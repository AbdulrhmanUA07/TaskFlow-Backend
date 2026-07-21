using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;  
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;
using Hangfire;




namespace TaskFlow.Application.Features.Tasks.Commands.CreateTask
{
    internal class CreateTaskHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IBackgroundJobService _backgroundJob;
        private readonly INotificationService _notificationService;
        public CreateTaskHandler(ITaskRepository taskRepository , ICategoryRepository categoryRepository, ICurrentUserService currentUser ,
            IBackgroundJobService backgroundJob , INotificationService notificationService)
        {
            _taskRepository = taskRepository;
            _categoryRepository = categoryRepository;
            _currentUser = currentUser;
            _backgroundJob = backgroundJob;
            _notificationService = notificationService;


        }

        public async Task<int> Handle(
       CreateTaskCommand request,
       CancellationToken cancellationToken)
        {
            
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category is null)
                throw new Exception("Category not found.");

            var task = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                Priority = (TaskPriority)request.Priority,
                Status = (TaskStats)request.Status,
                DueDate = request.DueDate,
                CategoryId = request.CategoryId
            };


            task.UserId = _currentUser.UserId!;
            await _taskRepository.AddAsync(task);
            _backgroundJob.EnqueueTaskCreatedEmail(
                    "abdulrhman11122TT@gmail.com",
                       task.Title);

            await _notificationService.TaskCreated(task.Title);


            return task.Id;
        }




    }
}