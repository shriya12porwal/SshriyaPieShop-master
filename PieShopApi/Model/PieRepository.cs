namespace PieShopApi.Model
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly ICategoryRepository categoryRepostiory;
        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Pie> AllPies => appDbContext.Pies;

        public IEnumerable<Pie> GetPieById(int pieId)
        {
            return AllPies.Where(pie => pie.PieId == pieId);
        }

        public IEnumerable<Pie> PiesOfTheWeek()
        {
            return AllPies.Where(pies => pies.IsPieOfTheWeek);
        }
    }
}
