using Microsoft.AspNetCore.Mvc;
using SshriyaPieShop.Models;

namespace SshriyaPieShop.Components
{
    public class FilterMenu : ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;
        public FilterMenu(ICategoryRepository categoryRepository)
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
