namespace PieShopApi.Model
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IPieRepository pieRepository;
        public OrderRepository(AppDbContext appDbContext ,IPieRepository pieRepository)
        {
            this.appDbContext = appDbContext;
            this.pieRepository = pieRepository;
        }
        public IEnumerable<Order> AllOrders => this.appDbContext.Orders;

        public Order AddOrder(Order order)
        {
            var entity = appDbContext.Orders.Add(order);
            appDbContext.SaveChanges();
            return entity.Entity;
        }

        public Order DeleteOrder(int  orderid)
        {
            var order = AllOrders.Where(order => order.Id == orderid).FirstOrDefault();
            var entity = appDbContext.Orders.Remove(order);
            appDbContext.SaveChanges();
            return entity.Entity;
        }

        public Order UpdateOrder(Order order)
        {
            var entity = appDbContext.Orders.Update(order);
            appDbContext.SaveChanges();
            return entity.Entity;
        }
    }
}
