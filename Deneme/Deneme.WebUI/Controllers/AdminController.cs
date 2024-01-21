using Deneme.Business.Services;
using Deneme.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public AdminController(IOrderService orderService,IOrderDetailService orderDetailService)
        {
                _orderService = orderService;
            _orderDetailService = orderDetailService;   
        }
        public IActionResult OrderControl()
        {
            var orderVm = _orderService.GetAllOrder().OrderByDescending(x => x.CreateDate).Select(x => new OrderVm()
            {
                Id = x.Id,
               UserName = x.UserName,
               OrderStatus=x.OrderStatu,
               TotalPrice=x.TotalPrice,
               CreatedDate = x.CreateDate,
            }).ToList();
          
            ViewBag.OrderVm = orderVm;  
            return View();
        }

        public IActionResult CargoEdit(CargoVm cargoVm) 
        {
            var cargoEdit=_orderService.GetOrder(cargoVm.OrderId);
            cargoEdit.CargoNo = cargoVm.CargoNo;
            cargoEdit.OrderStatu = Data.Enum.OrderStatusEnum.KargoyaVerildi;
            _orderService.EditOrder(cargoEdit);
            return RedirectToAction("OrderControl");
        
        }

        public IActionResult OrderCheck(int  id) 
        {
            var cargoEdit=_orderService.GetOrder(id);
            cargoEdit.OrderStatu = Data.Enum.OrderStatusEnum.TeslimEdildi;
           _orderService.EditOrder(cargoEdit);
            return RedirectToAction("OrderControl");
        }

        public IActionResult PendingOrder()
        {
            var orderVm = _orderService.GetAllOrder().OrderByDescending(x => x.CreateDate).Where(x=>x.OrderStatu==Data.Enum.OrderStatusEnum.KargoyaVerildi).Select(x => new OrderVm()
            {
                Id = x.Id,
                UserName = x.UserName,
                OrderStatus = x.OrderStatu,
                TotalPrice = x.TotalPrice,
                CreatedDate = x.CreateDate,
            }).ToList();

            ViewBag.OrderVm = orderVm;
            return View();

          
        }
        public IActionResult CompletedOrder()
        {
            var orderVm = _orderService.GetAllOrder().OrderByDescending(x => x.CreateDate).Where(x => x.OrderStatu == Data.Enum.OrderStatusEnum.TeslimEdildi).Select(x => new OrderVm()
            {
                Id = x.Id,
                UserName = x.UserName,
                OrderStatus = x.OrderStatu,
                TotalPrice = x.TotalPrice,
                CreatedDate = x.CreateDate,
            }).ToList();

            ViewBag.OrderVm = orderVm;
            return View();


        }
        public IActionResult PreparedOrders() 
        {
            var orderVm = _orderService.GetAllOrder().OrderByDescending(x => x.CreateDate).Where(x => x.OrderStatu == Data.Enum.OrderStatusEnum.SiparisHazırlanıyor).Select(x => new OrderVm()
            {
                Id = x.Id,
                UserName = x.UserName,
                OrderStatus = x.OrderStatu,
                TotalPrice = x.TotalPrice,
                CreatedDate = x.CreateDate,
            }).ToList();

            ViewBag.OrderVm = orderVm;
            return View();

        }
    }
}
