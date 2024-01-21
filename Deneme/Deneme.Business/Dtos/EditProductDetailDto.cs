using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Dtos
{
    public class EditProductDetailDto
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }

        public int VeritansDetailId { get; set; }

       public string ProductName { get; set; }

        public string ImagePath {  get; set; }

        public int Quantity { get; set; }
    }
}
