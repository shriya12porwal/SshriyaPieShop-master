namespace SshriyaPieShop.Models
{
    public class Cart
    {
        public int PieId { get; set; }
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int bill { get; set; }
       
    }
}
