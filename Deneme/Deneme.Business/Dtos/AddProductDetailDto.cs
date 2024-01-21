using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Dtos
{
   public  class AddProductDetailDto
    {

        public int ProductId { get; set; }

        public int VeritansDetailId { get; set; }

       

        public int Quantity { get; set; }
    }
}
