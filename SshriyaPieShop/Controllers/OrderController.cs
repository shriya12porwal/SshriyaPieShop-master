/*using Microsoft.AspNetCore.Mvc;
using SshriyaPieShop.Models;

namespace SshriyaPieShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPieRepository _pieRepostiory;
        public ViewResult AddToCart(int id)
        {
            var pie = _pieRepostiory.AllPies.FirstOrDefault(pie => pie.PieId == id);
            return View(pie);


        }
    }
}
*/