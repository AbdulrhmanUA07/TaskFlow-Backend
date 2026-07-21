using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TaskFlow.Infrastructure.Identity.Seed
{
    public static class AdminSeeder
    {
        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var admin = await userManager.FindByEmailAsync("admin@taskflow.com");

            if (admin != null)
                return;

            admin = new ApplicationUser
            {
                FullName = "System Admin",
                UserName = "admin@taskflow.com",
                Email = "admin@taskflow.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(admin, "Admin@123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }


    }
}
