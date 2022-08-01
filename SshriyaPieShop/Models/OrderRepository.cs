namespace SshriyaPieShop.Models { }
/*{
    public class OrderRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IPieRepository pieRepository;
        public OrderRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Pie> AddToCart(int pieId)
        {
            var pie = pieRepository.AllPies.Where(pie => pie.PieId == pieId);
            *//*this.appDbContext.AddTOCart.Add(pie);
            this._context.SaveChanges();

            return pie.Entity;*//*
            return pie;
        }
    }
}
*/