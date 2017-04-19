using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace Architecture.Database.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser<int>
    {
        public IEnumerable<Rating> Ratings { get; set; } = new List<Rating>();

        public IEnumerable<Cart> Carts { get; set; } = new List<Cart>();
    }
}
