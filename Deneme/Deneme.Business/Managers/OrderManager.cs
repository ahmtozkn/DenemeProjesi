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
   public  class OrderManager : IOrderService
    {
        private readonly IRepository<OrderEntity> _orderRepository;
        public OrderManager(IRepository<OrderEntity> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public int AddOrder(AddOrderDto addOrderDto)
        {
            var orderEntity = new OrderEntity()
            {
                UserId = addOrderDto.UserId,
                OrderStatus = addOrderDto.OrderStatu,
                TotalPrice = addOrderDto.TotalPrice,
            };
            _orderRepository.Add(orderEntity);
            return orderEntity.Id;
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
           
        }

        public void EditOrder(EditOrderDto editOrderDto)
        {
            var entityOrder = _orderRepository.GetById(editOrderDto.Id);
            entityOrder.OrderStatus = editOrderDto.OrderStatu;
            entityOrder.UserId = editOrderDto.UserId;
            entityOrder.Id=editOrderDto.Id;
            entityOrder.TotalPrice = editOrderDto.TotalPrice;
            _orderRepository.Update(entityOrder);
          

        }

        public List<ListOrderDto> GetAllOrder()
        {
            var listOrderDto = _orderRepository.GetAll().Select(X => new ListOrderDto()
            {
                Id= X.Id,   
                UserId=X.UserId,
                TotalPrice=X.TotalPrice,
                OrderStatu=X.OrderStatus,
                CreateDate=X.CreateDate,
                UserName=X.User.UserName,


            }).ToList();
            return listOrderDto;    
        }

        public EditOrderDto GetOrder(int id)
        {
          var orderEntity= _orderRepository.GetById(id);
            var editOrderDto = new EditOrderDto()
            {
                Id = id,    
                UserId=orderEntity.UserId,
                TotalPrice=orderEntity.TotalPrice,
                OrderStatu=orderEntity.OrderStatus,
                


            };

            return editOrderDto;
        }
    }
}
