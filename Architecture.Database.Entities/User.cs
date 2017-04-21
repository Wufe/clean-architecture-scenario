using Architecture.Database.Entities.Shared;
using Architecture.Models.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace Architecture.Database.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser<int>, IEntity
    {
        public IEnumerable<Rating> Ratings { get; set; } = new List<Rating>();

        public IEnumerable<ProductUser> ProductUsers { get; set; } = new List<ProductUser>();
    }
}
