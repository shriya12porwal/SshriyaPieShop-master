namespace SshriyaPieShop.Models
{
    public interface IPieRepository
    {
        // middle page
        IEnumerable<Pie> AllPies { get; }
        // 1 page
        IEnumerable<Pie> PiesOfTheWeek();
        //3rd Page
        IEnumerable<Pie> GetPieById(int pieId);
       // IEnumerable<Pie> AddToCart(int pieId);
       /* IEnumerable<Pie> FruitsPies();
        IEnumerable<Pie> Cheesecakes();

        IEnumerable<Pie> Seasonalpies();*/

    }
}
