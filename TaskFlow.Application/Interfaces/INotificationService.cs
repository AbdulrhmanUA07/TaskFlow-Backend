using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.Interfaces
{
    public interface INotificationService
    {

        Task TaskCreated(string title);

        Task TaskUpdated(string title);

        Task TaskDeleted(int id);

    }
}
