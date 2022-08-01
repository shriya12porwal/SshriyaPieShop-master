namespace PieShopApi.Model
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        public Category CreateCategory(Category category);
        public Category UpdateCategory(Category category);

        public Category RemoveCategory(Category category);

       /* public Pie UpdatePie(Pie pie);
        public Pie RemovePie(Pie pie);*/
    }
}

