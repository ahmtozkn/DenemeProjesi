using Deneme.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.Entities
{
   public  class OrderEntity:BaseEntity
    {
        public string UserId {  get; set; }

        public decimal? TotalPrice {  get; set; }

        public string? CargoNo {  get; set; }    
     
        public OrderStatusEnum  OrderStatus { get; set; }

        public ApplicationUser User { get; set; }

        public List<OrderDetailEntity> OrderDetails {  get; set; }
    }
}
