using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Dtos
{
    public  class ListProductDetailDto
    {

        public int Id {  get; set; }
        public int ProductId { get; set; }

        public int VeritansDetailId { get; set; }

     public decimal? Price { get; set; }

        public int Quantity { get; set; }

        public string? VertianName {  get; set; } 
        
        public string? ProductName {  get; set; }

        public string ImagePath {  get; set; }  

    }
}
