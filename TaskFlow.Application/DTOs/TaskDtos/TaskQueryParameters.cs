using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.DTOs.TaskDtos
{
    public class TaskQueryParameters
    {

        public string? Search { get; set; }

        public int? Status { get; set; }

        public int? Priority { get; set; }

        public int? CategoryId { get; set; }

        public string? SortBy { get; set; }

        public bool Descending { get; set; } = false;

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }

}
