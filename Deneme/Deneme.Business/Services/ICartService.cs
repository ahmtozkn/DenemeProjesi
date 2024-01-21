using Deneme.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Services
{
    public  interface ICartService
    {
        int AddCart(AddCartDto addCartDto);
        void EditCart(EditCartDto editCartDto);

        void DeleteCart(int id);    

        List<ListCartDto> GetAllCarts();

        EditCartDto GetCart (int id);   

    }
}
