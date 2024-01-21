using Deneme.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Services
{
   public  interface IOrderDetailService
    {
        void AddOrderDetail(AddOrderDetailDto addOrderDetailDto);

        void EditOrderDetail(EditOrderDetailDto editOrderDetailDto);

        List<ListOrderDetailDto> GetAllOrderDetail();

       EditOrderDetailDto GetOrderDetail(int id);

        void DeleteOrderDetail(int id);

    }
}
