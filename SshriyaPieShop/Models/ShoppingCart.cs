using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace SshriyaPieShop.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;

        public string ShoppingCartId { get; set; }
        private readonly IHttpContextAccessor httpContextAccessor;
        
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        private ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
           // this.httpContextAccessor = httpContextAccessor;
        }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
           // string user = httpContextAccessor.HttpContext.User.Identity.Name;

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------
        
        public void AddToCart(Pie pie, int amount,string username)
        {
           
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId );
            //if it is the first time they are adding apple pie, then shoppingCartItem should be null
            if (shoppingCartItem == null)
            {
                //shoppingcartitem object and add it to customer bag
                if (username != null)
                {
                    shoppingCartItem = new ShoppingCartItem
                    {
                        ShoppingCartId = ShoppingCartId,
                        Pie = pie,
                        Amount = 1,
                        Username = username
                    };
                }
                
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }
        
        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                //if they have more than 1 apple pie, you should reduce the count
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }
        public int IncreaseItem(Pie pie, string username)
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.Username == username);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                //if they have more than 1 apple pie, you should reduce the count
                
                    shoppingCartItem.Amount++;
                    localAmount = shoppingCartItem.Amount;
                
                    _appDbContext.ShoppingCartItems.Update(shoppingCartItem);
                
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }
        public int DecreaseItem(Pie pie, string username)
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.Username == username);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                //if they have more than 1 apple pie, you should reduce the count
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _appDbContext.ShoppingCartItems
                           .Include(s => s.Pie)
                           .ToList());
        }


        public List<ShoppingCartItem> GetShoppingCartItemsbyUsername(string username)
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _appDbContext.ShoppingCartItems.Where(c => c.Username == username)
                           .Include(s => s.Pie)
                           .ToList());
        }
        public void ClearCart()
        {
            var cartItems = _appDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }


       

    }
}
