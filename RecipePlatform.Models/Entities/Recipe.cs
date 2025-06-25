using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.Models.Entities.Enum;
using RecipePlatform.Models.Entities.UserManagement;

namespace RecipePlatform.Models.Entities
{
    public class Recipe : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeOnly PrepTimeMinutes { get; set; }
        public TimeOnly CookTimeMinutes { get; set; }
        public int Servings { get; set; }
        public DifficultyLevel Difficulty { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual IEnumerable<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public virtual IEnumerable<Instruction> Instructions { get; set; } = new List<Instruction>();

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } // Navigation property to the Category
        public int CategoryId { get; set; } // Foreign key to the Category


        public virtual IEnumerable<Rating> Ratings { get; set; } = new List<Rating>();


        // Foreign key to the User who made the recipe
        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser ApplicationUser { get; set; } // Navigation property to the ApplicationUser
        public string UserID { get; set; } // Foreign key to the ApplicationUser


    }
}
