using Deneme.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Services
{
  public  interface ICartItemService
    {
        void AddCartItem(AddCartItemDto addCartItemDto);
        void EditCartItem(EditCartItemDto editCartItemDto);

        void DeleteCartItem(int id);    

        List<ListCartItemDto> GetAllCartItems();

        EditCartItemDto GetCartItem(int id);
    }
}
