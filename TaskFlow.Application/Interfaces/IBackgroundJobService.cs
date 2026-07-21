using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.Interfaces
{
    public interface IBackgroundJobService
    {
        void EnqueueTaskCreatedEmail(string email, string title);
    }

}
