namespace PieShopApi.Model
{
    public interface IOrderRepository
    {
        IEnumerable<Order> AllOrders { get; }
        public Order AddOrder(Order order);
        public Order UpdateOrder(Order order);
        
        //public Order DeleteOrder(int orderid);
    }
}
