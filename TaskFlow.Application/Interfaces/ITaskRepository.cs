using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.TaskDtos;
using TaskFlow.Domain.Entities;


namespace TaskFlow.Application.Interfaces
{
    public interface ITaskRepository 
    {

        Task<TaskItem> AddAsync(TaskItem task);

        Task<List<TaskItem>> GetAllAsync(string userId, TaskQueryParameters parameters);

        Task<TaskItem?> GetByIdAsync(  int id, string userId);
        Task UpdateAsync(TaskItem task);

        Task DeleteAsync(TaskItem task);

    }
}
