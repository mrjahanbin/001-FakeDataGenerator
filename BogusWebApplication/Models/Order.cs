namespace BogusWebApplication.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
