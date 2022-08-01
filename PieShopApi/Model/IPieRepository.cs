namespace PieShopApi.Model
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        
        IEnumerable<Pie> PiesOfTheWeek();
        
        IEnumerable<Pie> GetPieById(int pieId);
    }
}
