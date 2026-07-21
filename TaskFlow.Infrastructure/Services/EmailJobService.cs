using TaskFlow.Application.Interfaces;

namespace TaskFlow.Infrastructure.Services;


 public class EmailService : IEmailService
    {
        public Task SendTaskCreatedEmailAsync(string email, string taskTitle)
        {
            Console.WriteLine($"Email sent to {email}");
            Console.WriteLine($"Task : {taskTitle}");

            return Task.CompletedTask;
        }
 }
