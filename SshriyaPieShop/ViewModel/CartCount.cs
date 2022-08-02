using Microsoft.AspNetCore.Mvc;
using SshriyaPieShop.Models;

namespace SshriyaPieShop.ViewModel
{
    public class CartCount : Controller
    {
        public IEnumerable<Order> orders { get; set; }
        public int count { get; set; }
        public int total { get; set; }
    }
}
