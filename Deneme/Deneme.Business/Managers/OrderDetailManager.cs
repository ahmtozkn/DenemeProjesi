using Deneme.Business.Dtos;
using Deneme.Business.Services;
using Deneme.Data.Entities;
using Deneme.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Managers
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IRepository<OrderDetailEntity> _orderDetailRepository;

        public OrderDetailManager(IRepository<OrderDetailEntity> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public void AddOrderDetail(AddOrderDetailDto addOrderDetailDto)
        {
            var orderDetailEntity = new OrderDetailEntity()
            {
                ImagePath = addOrderDetailDto.ImagePath,
                OrderId = addOrderDetailDto.OrderId,
                Price = addOrderDetailDto.Price,
                ProductDetailId = addOrderDetailDto.ProductDetailId,
                Quantity = addOrderDetailDto.Quantity,



            };
            _orderDetailRepository.Add(orderDetailEntity);
            
        }

        public void DeleteOrderDetail(int id)
        {
          _orderDetailRepository.Delete(id);
        }

        public void EditOrderDetail(EditOrderDetailDto editOrderDetailDto)
        {
            var orderDetailEntity = _orderDetailRepository.GetById(editOrderDetailDto.Id);
            orderDetailEntity.ImagePath = editOrderDetailDto.ImagePath; 
            orderDetailEntity.OrderId= editOrderDetailDto.OrderId;  
            orderDetailEntity.Price = editOrderDetailDto.Price;
            orderDetailEntity.ProductDetailId = editOrderDetailDto.ProductDetailId;
            orderDetailEntity.Quantity = editOrderDetailDto.Quantity;
            _orderDetailRepository.Update(orderDetailEntity);

        }

        public List<ListOrderDetailDto> GetAllOrderDetail()
        {
          var listDetailDto=_orderDetailRepository.GetAll().Select(X=> new ListOrderDetailDto()
          {
              Id = X.Id,
              ImagePath = X.ImagePath,  
              OrderId = X.OrderId,
              ProductDetailId=X.ProductDetailId,
              Quantity = X.Quantity,
              Price = X.Price,
              VeriantName=X.ProductDetail.VeriantDetail.Name,
              ProductName=X.ProductDetail.Product.Name


          }).ToList();
             return listDetailDto;
        }

        public EditOrderDetailDto GetOrderDetail(int id)
        {
           var entityDetail= _orderDetailRepository.GetById(id);

            var editOrderDetailDto = new EditOrderDetailDto()
            {

                Id = id,
                ImagePath = entityDetail.ImagePath,
                OrderId = entityDetail.OrderId,
                ProductDetailId = entityDetail.ProductDetailId,
                Quantity = entityDetail.Quantity,
            };
            return editOrderDetailDto;
        }
    }
}
