namespace PieShopApi.Model
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek();
       IEnumerable<Category> DetailsofCategory(int categoryId);
        IEnumerable<Pie> Details(int pieId);
        public Pie CreatePie(Pie pie);
        public Pie UpdatePie(Pie pie);
        public Pie RemovePie(Pie pie);
    }
}