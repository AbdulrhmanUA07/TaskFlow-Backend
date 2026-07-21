using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Enums
{
    public enum TaskStats
    {
        Pending = 1,
        InProgress,
        Completed,
        Cancelled
    }
}
