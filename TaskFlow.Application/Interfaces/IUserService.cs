using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.UserDtos;

namespace TaskFlow.Application.Interfaces
{
    public interface IUserService
    {

        Task<List<UserDto>> GetAllAsync();

        Task<UserDto?> GetByIdAsync(string id);

        Task ChangeRoleAsync(string id, string role);

        Task DeleteAsync(string id);

        Task LockAsync(string id);

        Task UnlockAsync(string id);

    }
}
