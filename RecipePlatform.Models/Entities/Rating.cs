using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.Models.Entities.UserManagement;

namespace RecipePlatform.Models.Entities
{
    public class Rating : BaseEntity
    {
        public int RatingStar { get; set; } 
        public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now); // Default to current date
        public DateOnly UpdatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now); // Default to current date

        // Foreign key to the Recipe
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; } // Navigation property to the Recipe
        public int RecipeId { get; set; }


        // Foreign key to the User who made the rating
        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser ApplicationUser { get; set; } // Navigation property to the ApplicationUser
        public string UserID { get; set; } // Foreign key to the ApplicationUser
    }
}
