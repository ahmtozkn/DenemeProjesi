using Deneme.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Dtos
{
    public class AddOrderDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string? CargoNo {  get; set; }
        public OrderStatusEnum OrderStatu { get; set; }

        public decimal? TotalPrice { get; set; }


    }   
}
