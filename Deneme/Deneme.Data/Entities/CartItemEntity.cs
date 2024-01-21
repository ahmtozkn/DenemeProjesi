using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.Entities
{
   public class CartItemEntity:BaseEntity
    {
        public int CartId { get; set; }
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }

        public CartEntity Cart { get; set; }

        public ProductDetailEntity ProductDetail { get; set; }
    }
}
