using Microsoft.AspNetCore.Mvc.Rendering;
using RecipePlatform.Models.Entities;
using RecipePlatform.Models.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace RecipePlatform.PL.MVC.Models
{
    public class AddRecipeViewModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public TimeOnly PrepTimeMinutes { get; set; }

        [Required]
        public TimeOnly CookTimeMinutes { get; set; }

        [Required]
        public int Servings { get; set; }

        [Required]
        public DifficultyLevel Difficulty { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem>? Categories { get; set; }

        public List<string> Ingredient { get; set; } = new();
        public List<string> Instruction { get; set; } = new();

    }
}
