using Microsoft.AspNetCore.Mvc;
using SshriyaPieShop.Models;

namespace SshriyaPieShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categories = this.categoryRepository.AllCategories;
            return View(categories);
        }
    }
}
