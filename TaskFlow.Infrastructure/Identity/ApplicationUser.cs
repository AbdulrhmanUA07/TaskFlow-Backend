using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities;
namespace TaskFlow.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
       public string FullName { get; set; } = string.Empty;

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}
