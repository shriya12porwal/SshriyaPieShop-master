using Microsoft.AspNetCore.Mvc;
using SshriyaPieShop.Models;
using SshriyaPieShop.ViewModel;

namespace SshriyaPieShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPieRepository pieRepostiory;
       
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration confriguration;
         
        public OrderController(IPieRepository _pieRepostiory ,IHttpContextAccessor httpContextAccessor, IConfiguration confriguration , AppDbContext appDbContext)
        {
            this.pieRepostiory = _pieRepostiory;
           
            this.httpContextAccessor = httpContextAccessor;
            this.confriguration = confriguration;
            this.appDbContext = appDbContext;   

        }
        
        public IActionResult ViewCart()
        
        {
            string cartid = this.httpContextAccessor.HttpContext.User.Identity.Name;
            if (cartid == "Shriya@gmail.com")
            {
                var cart = appDbContext.Orders;
                
                return View(cart);

            }
            else
            {
                
                var cart = appDbContext.Orders.FirstOrDefault(o => o.CartId == cartid);
                
                return View(cart);
            }

        }
        public IActionResult IncreaseItem(int orderid)
        {
            //string cartid = this.httpContextAccessor.HttpContext.User.Identity.Name;
            var order = appDbContext.Orders.FirstOrDefault(o => o.OrderId == orderid);

            order.Quantity++;
            var updateorder = pieRepostiory.UpdateOrder(order);
            return Redirect("ViewCart");

        }
        public IActionResult DecreaseItem(int orderid)
        {
            var order = appDbContext.Orders.FirstOrDefault(o => o.OrderId == orderid);
            if(order.Quantity>1)
            {
                order.Quantity--;
                
                var updateorder = pieRepostiory.UpdateOrder(order);
            }
            


            return Redirect("ViewCart");

        }
        public IActionResult RemoveOrder(int orderid)
        {
            var order = appDbContext.Orders.FirstOrDefault(o => o.OrderId ==orderid);
            var entity = this.appDbContext.Orders.Remove(order);
            this.appDbContext.SaveChanges();
            return Redirect("ViewCart");
        }
        
        public ViewResult CustomerForm()
        {
            return View();
        }
    }
}
