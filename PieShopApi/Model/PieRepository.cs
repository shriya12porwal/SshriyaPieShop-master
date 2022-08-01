namespace PieShopApi.Model
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly ICategoryRepository categoryRepository;
        public PieRepository(AppDbContext appDbContext, ICategoryRepository categoryRepository)
        {
            this.appDbContext = appDbContext;
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Pie> AllPies => appDbContext.Pies;
        public IEnumerable<Pie> PiesOfTheWeek()
        {
            return AllPies.Where(pies => pies.IsPieOfTheWeek);
        }
        public Pie CreatePie(Pie pie)
        {
            var entry = this.appDbContext.Pies.Add(pie);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }
        
        public Pie RemovePie(Pie pie)
        {
            //var pie = AllPies.FirstOrDefault(Pie=> Pie.PieId == pieId);
            var entry = this.appDbContext.Pies.Remove(pie);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }

        public Pie UpdatePie(Pie pie)
        {
            var entry = this.appDbContext.Pies.Update(pie);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }
        public IEnumerable<Category> DetailsofCategory(int categoryId)
        {
            var category = categoryRepository.AllCategories.Where(c => c.CategoryId == categoryId);
            return category;
        }


        public IEnumerable<Pie> Details(int pieId)
        {
            return AllPies.Where(pie => pie.PieId == pieId);
        }
    }
}
   