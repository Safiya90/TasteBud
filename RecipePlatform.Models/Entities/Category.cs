using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        // Navigation property to the Recipes in this category
        public virtual IEnumerable<Recipe> Recipes { get; set; } = new List<Recipe>();
        
    }
}
