using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Infrastructure.Identity;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.DTOs.UserDtos;
using TaskFlow.Domain.Common.Exceptions;

namespace TaskFlow.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task ChangeRoleAsync(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new NotFoundException("User not found");

            var currentRoles = await _userManager.GetRolesAsync(user);

            if (currentRoles.Any())
                await _userManager.RemoveFromRolesAsync(user, currentRoles);

            await _userManager.AddToRoleAsync(user, role);
        }

       

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = _userManager.Users.ToList();

            var result = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                result.Add(new UserDto
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email!,
                    Roles = roles,
                    IsLocked = user.LockoutEnd.HasValue &&
                               user.LockoutEnd > DateTimeOffset.UtcNow
                });
            }

            return result;
        }



        public async Task<UserDto?> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);

            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email!,
                Roles = roles,
                IsLocked = user.LockoutEnd.HasValue &&
                           user.LockoutEnd > DateTimeOffset.UtcNow
            };
        }



        public async Task LockAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new NotFoundException("User not found");

            user.LockoutEnd = DateTimeOffset.UtcNow.AddHours(24);

            await _userManager.UpdateAsync(user);
        }


        public async Task UnlockAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new NotFoundException("User not found");

            user.LockoutEnd = null;

            await _userManager.UpdateAsync(user);
        }


        public async Task DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new NotFoundException("User not found");

            await _userManager.DeleteAsync(user);
        }
    }
}
