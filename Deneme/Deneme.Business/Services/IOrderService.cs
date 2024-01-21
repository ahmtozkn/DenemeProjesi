using Deneme.Business.Dtos;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Services
{
    public interface IOrderService
    {
        int AddOrder(AddOrderDto addOrderDto);

        void EditOrder(EditOrderDto editOrderDto);

        List<ListOrderDto> GetAllOrder();

        EditOrderDto GetOrder(int id);  

        void DeleteOrder(int id);   
       
    }
}
