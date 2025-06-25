using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipePlatform.Models.Entities;
using RecipePlatform.BLL.Interfaces;

namespace RecipePlatform.PL.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IGenericRepository<Category> _category;

        public CategoryController(IGenericRepository<Category> category)
        {
            _category = category;
        }

        // Show all categories
        public async Task<IActionResult> List()
        {
            var categories = await _category.GetAllAsync();
            return View(categories);
        }

        // GET: Category/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: Category/Add
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            await _category.AddAsync(category);
            return RedirectToAction(nameof(List));
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _category.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Category/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            await _category.UpdateAsync(category);
            return RedirectToAction(nameof(List));
        }

        // POST: Category/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _category.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            await _category.DeleteAsync(category);
            return RedirectToAction(nameof(List));
        }
    }
}
