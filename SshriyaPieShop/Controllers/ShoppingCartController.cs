using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SshriyaPieShop.Models;
using SshriyaPieShop.ViewModel;

namespace SshriyaPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration confriguration;

        public ShoppingCartController(IPieRepository pieRepository, ShoppingCart shoppingCart, IHttpContextAccessor httpContextAccessor, IConfiguration confriguration)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
            this.httpContextAccessor = httpContextAccessor;
            this.confriguration = confriguration;
        }

        public ViewResult Index()
        {
            string username = this.httpContextAccessor.HttpContext.User.Identity.Name;
           
            if (username == "Shriya@gmail.com")
            {
                var items = _shoppingCart.GetShoppingCartItems();

                _shoppingCart.ShoppingCartItems = items;
            }
            else
            {
                var items = _shoppingCart.GetShoppingCartItemsbyUsername(username);

                _shoppingCart.ShoppingCartItems = items;
            }


            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int pieId)
        {

            var selectedPie = _pieRepository.AllPies.FirstOrDefault(pie => pie.PieId == pieId);
            string username = this.httpContextAccessor.HttpContext.User.Identity.Name;
            if (selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie, 1, username);
            }


            return RedirectToAction("Index");
        }
       /* public RedirectToActionResult Wishlist(int pieId)
        {

            var selectedPie = _pieRepository.AllPies.FirstOrDefault(pie => pie.PieId == pieId);
            string username = this.httpContextAccessor.HttpContext.User.Identity.Name;
            if (selectedPie != null)
            {
                _shoppingCart.Wishlist(selectedPie, 1, username);
            }


            return RedirectToAction("Wishlist");
        }*/



        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }


        public RedirectToActionResult ClearCart()
        {
            _shoppingCart.ClearCart();

            return RedirectToAction("Index");
        }
        public RedirectToActionResult IncreaseItem(int pieId)
        {
            //string cartid = this.httpContextAccessor.HttpContext.User.Identity.Name;
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            string username = this.httpContextAccessor.HttpContext.User.Identity.Name;
            if (selectedPie != null)
            {
                _shoppingCart.IncreaseItem(selectedPie,username);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult DecreaseItem(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            string username = this.httpContextAccessor.HttpContext.User.Identity.Name;
            if (selectedPie != null)
            {
                _shoppingCart.DecreaseItem(selectedPie,username);
            }
            return RedirectToAction("Index");
        }
    }
}