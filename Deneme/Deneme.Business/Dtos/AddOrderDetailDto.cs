using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Dtos
{
  public  class AddOrderDetailDto
    {

        public int Id { get; set; } 
        public int OrderId { get; set; }

        public int ProductDetailId { get; set; }

        public int Quantity { get; set; }

        public decimal? Price { get; set; }

        public string ImagePath { get; set; }

    }
}
