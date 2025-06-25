using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.DAL.Context;
using RecipePlatform.Models.Entities;

namespace RecipePlatform.BLL.Repositories
{
    public class RecipeService : IRecipeService
    {
        private readonly IGenericRepository<Recipe> _recipeRepository;

        public RecipeService(IGenericRepository<Recipe> recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            await _recipeRepository.AddAsync(recipe);
        }

        public async Task<IEnumerable<Recipe>> GetUserRecipesAsync(string userId)
        {
            var all = await _recipeRepository.GetAllAsync();
            return all.Where(r => r.UserID == userId);
        }
    }
}
