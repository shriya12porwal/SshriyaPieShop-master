namespace SshriyaPieShop.Models
{
    public interface IPieRepository
    {
        // middle page
        IEnumerable<Pie> AllPies { get; }
        // 1 page
        IEnumerable<Order> AllOrders { get; }
        IEnumerable<Pie> PiesOfTheWeek();
        //3rd Page
        IEnumerable<Pie> GetPieById(int pieId);
       // IEnumerable<Pie> AddToCart(int pieId);
       /* IEnumerable<Pie> FruitsPies();
        IEnumerable<Pie> Cheesecakes();

        IEnumerable<Pie> Seasonalpies();*/
       public Pie CreatePie(Pie pie);
        public int CreateOrder(Order order);
        public Pie Remove(int pieid);
        public int UpdateOrder(Order order);
        //public Order RemoveOrder(Order order);
    }
}
