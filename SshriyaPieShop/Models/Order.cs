namespace SshriyaPieShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PieId { get; set; }
        public string PieName { get; set; }
        public string CartId { get; set; }
        public decimal PiePrice { get; set; }
        public int Quantity { get; set; }
      
    }
}

