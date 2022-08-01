using Microsoft.AspNetCore.Mvc;
using SshriyaPieShop.Models;

namespace SshriyaPieShop.ViewModel
{
    public class CategoryViewModel : Controller
    {
        public IActionResult Index()
        {
            Category category = new Category();
            ViewBag.CategoryID = category.CategoryId;
            return View();
        }
    }
}
