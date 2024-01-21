namespace Deneme.WebUI.Models
{
    public class OrderDetailVm
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        public int ProductDetailId { get; set; }

        public int Quantity { get; set; }

        public decimal? Price { get; set; }

        public string ProductName { get; set; }
        public string VeritansName {  get; set; }
        public string ImagePath { get; set; }
    }
}
