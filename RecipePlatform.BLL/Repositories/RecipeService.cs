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

        //public async Task AddRecipeAsync(Recipe recipe)
        //{
        //    await _recipeRepository.AddAsync(recipe);
        //}

        public async Task AddRecipeAsync(Recipe recipe)
        {
            
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Recipe = recipe; 
            }
            foreach (var instruction in recipe.Instructions)
            {
                instruction.Recipe = recipe;
            }
            await _recipeRepository.AddAsync(recipe);
        }
        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _recipeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Recipe>> GetUserRecipesAsync(string userId)
        {
            var all = await _recipeRepository.GetAllAsync();
            return all.Where(r => r.UserID == userId);
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            return await _recipeRepository.GetQuery()
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .Include(r => r.Category)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
