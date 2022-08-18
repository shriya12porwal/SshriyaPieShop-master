using Microsoft.AspNetCore.Mvc;
using SshriyaPieShop.Models;
using SshriyaPieShop.ViewModel;

namespace SshriyaPieShop.Controllers
{
    public class OrderController : Controller
    {
        /*private readonly IPieRepository pieRepostiory;

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration confriguration;

        public OrderController(IPieRepository _pieRepostiory, IHttpContextAccessor httpContextAccessor, IConfiguration confriguration, AppDbContext appDbContext)
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

                var cart = appDbContext.Orders.Where(cart => cart.CartId == cartid);
                return View(cart);
            }

        }
        public IActionResult IncreaseItem(int orderid)
        {
            //string cartid = this.httpContextAccessor.HttpContext.User.Identity.Name;
            var order = appDbContext.Orders.FirstOrDefault(o => o.OrderId == orderid);

            order.Quantity++;
            order.Bill = (int)(order.Quantity * order.PiePrice);
            var updateorder = pieRepostiory.UpdateOrder(order);
            return Redirect("ViewCart");

        }
        public IActionResult DecreaseItem(int orderid)
        {
            var order = appDbContext.Orders.FirstOrDefault(o => o.OrderId == orderid);
            if (order.Quantity > 1)
            {
                order.Quantity--;
                order.Bill = (int)(order.Quantity * order.PiePrice);
                var updateorder = pieRepostiory.UpdateOrder(order);
            }



            return Redirect("ViewCart");

        }
        public IActionResult RemoveOrder(int orderid)
        {
            var order = appDbContext.Orders.FirstOrDefault(o => o.OrderId == orderid);
            var entity = this.appDbContext.Orders.Remove(order);
            this.appDbContext.SaveChanges();
            return Redirect("ViewCart");
        }

        public ViewResult CustomerForm()
        {
            return View();
        }*/



        private readonly IOrderRepository orderRepository;
        private readonly ShoppingCart cart;
        public OrderController(IOrderRepository orderRepository, ShoppingCart cart)
        {
            this.orderRepository = orderRepository;
            this.cart = cart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order1)
        {
            var items = cart.GetShoppingCartItems();
            cart.ShoppingCartItems = items;
            if (cart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty,add some pie first");
            }
            if (ModelState.IsValid)
            {
                orderRepository.CreateOrder(order1);
                cart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order1);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order.";
            return View();
        }

    }
}