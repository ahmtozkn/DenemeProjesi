using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.Entities
{
    public class OrderDetailEntity:BaseEntity
    {

        public int OrderId {  get; set; }   

        public int ProductDetailId { get; set; }

        public int Quantity { get; set; }

        public decimal? Price { get; set; }

        public string ImagePath {  get; set; }

        public OrderEntity Order { get; set; }
        public ProductDetailEntity ProductDetail { get; set; }
    }
}
