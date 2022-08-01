
namespace PieShopApi.Model
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
       

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
           
        }
        public IEnumerable<Category> AllCategories => appDbContext.Categories;

        public Category CreateCategory(Category category)
        {
            var entry = this.appDbContext.Categories.Add(category);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }
        public Category UpdateCategory(Category category)
        {
            var entry = this.appDbContext.Categories.Update(category);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }
        public Category RemoveCategory(Category category)
        {
            //var pie = AllPies.FirstOrDefault(Pie=> Pie.PieId == pieId);
            var entry = this.appDbContext.Categories.Remove(category);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }














        /*  public Pie CreateCategory(Category category)
 {
     var entry = this.appDbContext.Categories.Add(category);
     this.appDbContext.SaveChanges();
     return entry.Entity;
 }
 public Pie RemoveCategory(int categoryid)
 {
     var category = AllCategories.FirstOrDefault(category => category.CategoryId == categoryid);
     var entry = this.appDbContext.Pies.Remove(category);
     this.appDbContext.SaveChanges();
     return entry.Entity;
 }

 public Pie UpdateCategory(Category category)
 {
     var entry = this.appDbContext.Pies.Update(category);
     this.appDbContext.SaveChanges();
     return entry.Entity;
 }*/

    }
}
       