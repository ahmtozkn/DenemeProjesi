using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.Entities
{
    public  class CartEntity:BaseEntity
    {

        public string UserId {  get; set; }
        public List<CartItemEntity> CartItems { get; set; }
        
    }
}
