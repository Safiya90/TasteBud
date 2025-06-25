using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.Models.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }

      
        public virtual Recipe Recipe { get; set; } // Navigation property to the Recipe
        public int RecipeId { get; set; } // Foreign key to the Recipe
    }
}
