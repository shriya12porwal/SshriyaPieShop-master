namespace SshriyaPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart shoppingCart;
        private readonly AppDbContext appDbContext;
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            this.appDbContext = appDbContext;
            this.shoppingCart = shoppingCart;
        }
       

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            var shoppingCartItems = this.shoppingCart.ShoppingCartItems;
            order.OrderTotal = shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            this.appDbContext.Add(order);
            this.appDbContext.SaveChanges();
        }
    }
}
