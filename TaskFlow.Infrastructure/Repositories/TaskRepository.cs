using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.TaskDtos;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Persistence;

namespace TaskFlow.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<TaskItem> AddAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task DeleteAsync(TaskItem task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
          
        }


        public async Task<List<TaskItem>> GetAllAsync(string userId, TaskQueryParameters parameters)
        {

            var query = _context.Tasks
                .Include(t => t.Category)
                .Where(t => t.UserId == userId)
                .AsQueryable();

            // Search
            if (!string.IsNullOrWhiteSpace(parameters.Search))
            {
                query = query.Where(t =>
                    t.Title.Contains(parameters.Search));
            }

            // Status
            if (parameters.Status.HasValue)
            {
                query = query.Where(t =>
                    (int)t.Status == parameters.Status);
            }

            // Priority
            if (parameters.Priority.HasValue)
            {
                query = query.Where(t =>
                    (int)t.Priority == parameters.Priority);
            }

            // Category
            if (parameters.CategoryId.HasValue)
            {
                query = query.Where(t =>
                    t.CategoryId == parameters.CategoryId);
            }

            // Sorting
            query = parameters.SortBy?.ToLower() switch
            {
                "duedate" => parameters.Descending
                    ? query.OrderByDescending(t => t.DueDate)
                    : query.OrderBy(t => t.DueDate),

                "title" => parameters.Descending
                    ? query.OrderByDescending(t => t.Title)
                    : query.OrderBy(t => t.Title),

                _ => query.OrderByDescending(t => t.Id)
            };

            query = query.Skip((parameters.Page - 1) * parameters.PageSize)
                         .Take(parameters.PageSize);

            return await query.ToListAsync();
        }



        public Task<TaskItem?> GetByIdAsync(int id, string userId)
        {
            return _context.Tasks.Include(t => t.Category).FirstOrDefaultAsync(t =>  t.Id == id && t.UserId == userId);

        }


        public async Task UpdateAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }


    }
}
