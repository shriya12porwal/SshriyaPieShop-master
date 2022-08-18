namespace SshriyaPieShop.Models
{
    public class Wishlist
    {
        public int ShoppingCartItemId { get; set; }
        public Pie Pie { get; set; }
        public int Amount { get; set; }
        public string Username { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
