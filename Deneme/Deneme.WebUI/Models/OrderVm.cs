using Deneme.Data.Enum;

namespace Deneme.WebUI.Models
{
    public class OrderVm
    {
        public int Id { get; set; } 
        public string UserId { get; set; }
        public string UserName {  get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
    }
}
