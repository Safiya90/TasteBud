using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.BLL.Interfaces
{
    public interface IRecipeService
    {
        Task AddRecipeAsync(Recipe recipe);
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<IEnumerable<Recipe>> GetUserRecipesAsync(string userId);
        Task<Recipe> GetByIdAsync(int id);
    }
}
