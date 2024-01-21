namespace Deneme.WebUI.Models
{
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int VeritansDetailId { get; set; }

       public string? ProductName { get; set; }    

        public decimal? Price { get; set; } 
        public string? VertianName {  get; set; }   
        public int Quantity { get; set; }

        public string ImagePath {  get; set; }
    }
}
