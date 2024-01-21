using Deneme.Data.Entities;

namespace Deneme.WebUI.Models
{
    public class CartItemVm
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public string ProductName {  get; set; }
        public string ImagePath {  get; set; }  
      
       
        public string VertiansName {  get; set; }
    }
}
