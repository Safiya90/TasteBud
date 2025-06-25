using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RecipePlatform.Models.Entities.Enum;

namespace RecipePlatform.Models.Entities.UserManagement
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsActive { get; set; } = true; // Default to true, meaning the user is active
        public virtual IEnumerable<Recipe> Recipes { get; set; } = new List<Recipe>(); // Navigation property for the Recipes created by the user
        public virtual IEnumerable<Rating> Ratings { get; set; } = new List<Rating>(); // Navigation property for the Ratings made by the user
    }
}
