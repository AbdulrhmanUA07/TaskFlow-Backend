using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category);

        Task<List<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int id);

        Task UpdateAsync(Category category);

        Task DeleteAsync(Category category); 
    }
}
