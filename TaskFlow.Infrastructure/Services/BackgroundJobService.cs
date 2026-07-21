using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Infrastructure.Services
{
    public class BackgroundJobService : IBackgroundJobService
    {
        public void EnqueueTaskCreatedEmail(string email, string title)
        {

            BackgroundJob.Enqueue<IEmailService>(x =>
                x.SendTaskCreatedEmailAsync(email, title));

        }

    }
}
