namespace PieShopApi.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int PieId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
      
        
    }
}
