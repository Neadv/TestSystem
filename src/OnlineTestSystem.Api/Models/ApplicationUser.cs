using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineTestSystem.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Test> AssignedTests { get; set; }
    } 
}
  