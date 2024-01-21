using Deneme.Business.Dtos;
using Deneme.Business.Services;
using Deneme.Data.Entities;
using Deneme.Data.InMemoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Managers
{
    public class CartManager : ICartService
    {

        private readonly InIRepository<CartEntity> _cartRepository; 
        public CartManager(InIRepository<CartEntity> cartRepository)
        {
                _cartRepository = cartRepository;
        }
        public int AddCart(AddCartDto addCartDto)
        {
            var cartEntity = new CartEntity()
            { 
                UserId=addCartDto.UserId,
            
            };
            _cartRepository.Add(cartEntity);
            return cartEntity.Id;
        }

        public void DeleteCart(int id)
        {
            _cartRepository.Delete(id);
        }

        public void EditCart(EditCartDto editCartDto)
        {
            var cartEntity=_cartRepository.GetById(editCartDto.Id);
            cartEntity.Id = editCartDto.Id;
            cartEntity.UserId= editCartDto.UserId;
            _cartRepository.Update(cartEntity);

        }

        public List<ListCartDto> GetAllCarts()
        {
           var listCartDto=_cartRepository.GetAll().Select(x=> new ListCartDto()
           {

               Id = x.Id,
               UserId=x.UserId
           }).ToList(); 
            return listCartDto; 
        }

        public EditCartDto GetCart(int id)
        {
          var card= _cartRepository.GetById(id);
            var editCartDto = new EditCartDto()
            {

                Id = id,
                UserId=card.UserId
            };
            return editCartDto;
        }
    }
}
