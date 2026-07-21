using Microsoft.AspNetCore.SignalR;
using TaskFlow.API.Hubs;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.API.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<TaskHub> _hub;

        public NotificationService(IHubContext<TaskHub> hub)
        {
            _hub = hub;
        }


        public async Task TaskCreated(string title)
        {
            await _hub.Clients.All.SendAsync(
                "TaskCreated",
                $"New Task Created : {title}");
        }

        public async Task TaskUpdated(string title)
        {
            await _hub.Clients.All.SendAsync(
                "TaskUpdated",
                $"Task Updated : {title}");
        }

        public async Task TaskDeleted(int id)
        {
            await _hub.Clients.All.SendAsync(
                "TaskDeleted",
                $"Task {id} Deleted");
        }

    }
}
