namespace SshriyaPieShop.Models
{
    public interface ICategoryRepository
    { 
        IEnumerable<Category> AllCategories { get; }
    }
}

   
