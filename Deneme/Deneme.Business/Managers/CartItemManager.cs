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
    public class CartItemManager : ICartItemService
    {
        private readonly InIRepository<CartItemEntity> _cartItemRepository;

        public CartItemManager(InIRepository<CartItemEntity> cartItemRepository)
        {
                _cartItemRepository = cartItemRepository;
        }
        public void AddCartItem(AddCartItemDto addCartItemDto)
        {
            var entity = new CartItemEntity()
            {
                CartId = addCartItemDto.CartId,
                Price = addCartItemDto.Price,
                Quantity = addCartItemDto.Quantity,
                ProductDetailId = addCartItemDto.ProductId,

            };
            _cartItemRepository.Add(entity);
        }

        public void DeleteCartItem(int id)
        {
           _cartItemRepository.Delete(id);
        }

        public void EditCartItem(EditCartItemDto editCartItemDto)
        {
            var cartItemEntity = _cartItemRepository.GetById(editCartItemDto.Id);
            cartItemEntity.Price = editCartItemDto.Price;
            cartItemEntity.Quantity = editCartItemDto.Quantity;
            cartItemEntity.ProductDetailId = editCartItemDto.ProductId;
            cartItemEntity.CartId = editCartItemDto.CartId;

            _cartItemRepository.Update(cartItemEntity);
        }

        public List<ListCartItemDto> GetAllCartItems()
        {
            var listcartItem=_cartItemRepository.GetAll();
            List<ListCartItemDto> dtos = new List<ListCartItemDto>();
            ListCartItemDto dto = new ListCartItemDto();
            
            var listCartItemDto = _cartItemRepository.GetAll().Select(X => new ListCartItemDto()
            {
                Id = X.Id,
                CartId=X.CartId,
                Price=X.Price,
                ProductId=X.ProductDetailId,
                Quantity=X.Quantity,
            
            }).ToList();
            return listCartItemDto; 
        }

        public EditCartItemDto GetCartItem(int id)
        {
            var entity=_cartItemRepository.GetById(id);
            var editCartItemDto = new EditCartItemDto()
            {
                Id = id,
                CartId = entity.CartId,
                Price = entity.Price,
                Quantity = entity.Quantity,
                ProductId = entity.ProductDetailId,
                

            };
            return editCartItemDto;

        }
    }
}
