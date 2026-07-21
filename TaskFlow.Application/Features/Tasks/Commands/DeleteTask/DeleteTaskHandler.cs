using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;  
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Common.Exceptions;



namespace TaskFlow.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly INotificationService _notificationService;
        public DeleteTaskHandler(ITaskRepository taskRepository , ICurrentUserService currentUser , INotificationService notificationService)
        {
            _taskRepository = taskRepository;
            _currentUser = currentUser;
            _notificationService = notificationService;
        }

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync( request.Id, _currentUser.UserId!);

            if (task == null)
                throw new NotFoundException("Task not found");

            await _taskRepository.DeleteAsync(task);
            await _notificationService.TaskDeleted(task.Id);
        }


    }
}