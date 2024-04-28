using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var categories = _categoryService.GetAllCategoryService();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetCategory(string categoryId)
        {
            if (!Guid.TryParse(categoryId, out Guid categoryIdGuid))
            {
                return BadRequest("Invalid category ID Format");
            }
            var category = _categoryService.GetCategoryById(categoryIdGuid);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }

        }

        [HttpPost]
        public IActionResult CreateCategory(Category newCategory)
        {
            var createdCategory = _categoryService.CreateCategoryService(newCategory);
            return CreatedAtAction(nameof(GetCategory), new { categoryId = createdCategory.CategoryId }, createdCategory);
        }


        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(string categoryId, Category updateCategory)
        {
            if (!Guid.TryParse(categoryId, out Guid categoryIdGuid))
            {
                return BadRequest("Invalid category ID Format");
            }
            var category = _categoryService.UpdateCategoryService(categoryIdGuid, updateCategory);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(string categoryId)
        {
            if (!Guid.TryParse(categoryId, out Guid categoryIdGuid))
            {
                return BadRequest("Invalid category ID Format");
            }
            var result = _categoryService.DeleteCategoryService(categoryIdGuid);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}