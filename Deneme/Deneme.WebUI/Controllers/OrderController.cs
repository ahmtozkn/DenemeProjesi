using Deneme.Business.Dtos;
using Deneme.Business.Services;
using Deneme.Data.Entities;
using Deneme.Data.Enum;
using Deneme.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IProductDetailService _productDetailService;
        public OrderController(IOrderService orderService,IOrderDetailService orderDetailService,UserManager<ApplicationUser> userManager,ICartService cartService, ICartItemService cartItemService,IProductDetailService productDetailService)
        {
            _orderDetailService = orderDetailService;
            _userManager = userManager; 
            _cartService = cartService; 
            _cartItemService = cartItemService;
            _productDetailService = productDetailService;
            _orderService = orderService;
           
        }
        public  async Task <IActionResult> Index()
        {
            var user=await _userManager.GetUserAsync(User);

           var orderList= _orderService.GetAllOrder().OrderByDescending(x => x.CreateDate).Where(x => x.UserId == user.Id).Select(x => new OrderVm()
            {
                Id= x.Id,
                OrderStatus=x.OrderStatu,
                TotalPrice=x.TotalPrice,
                UserId=user.Id,
                CreatedDate=x.CreateDate,
            }).ToList();
            var orderDetailList = _orderDetailService.GetAllOrderDetail().Select(X => new OrderDetailVm()
            {
                Id= X.Id,   
                ImagePath=X.ImagePath,
                OrderId=X.OrderId,
                Price = X.Price,
                ProductDetailId = X.ProductDetailId,
                Quantity = X.Quantity,
                
               
               

            }).ToList();
            
           
            
           
             ViewBag.OrderDetail = orderDetailList;

            return View(orderList);
        }
        
        public async Task <IActionResult> Add() 
        {
            var user = await _userManager.GetUserAsync(User);
            
                var addOrderDto = new AddOrderDto()
                {
                UserId = user.Id,
                OrderStatu = OrderStatusEnum.SiparisHazırlanıyor,
                TotalPrice= 0,
                };
                var orderId= _orderService.AddOrder(addOrderDto);
                var Total = 0;
                var cartGetDto=_cartService.GetAllCarts().FirstOrDefault(x=>x.UserId==user.Id);
                var addOrderDetailDto = new AddOrderDetailDto();
                var cartItemDto = _cartItemService.GetAllCartItems().Where(x => x.CartId == cartGetDto.Id).ToList(); 
                foreach(var item in cartItemDto)
                {
              

                    addOrderDetailDto.OrderId = orderId;
                    addOrderDetailDto.ProductDetailId = item.ProductId;
                    addOrderDetailDto.Quantity = item.Quantity;
                    addOrderDetailDto.Price = item.Price;
                    Total += (int)item.Price*item.Quantity;
                    var productDetail = _productDetailService.GetAllProductDetail().FirstOrDefault(X=>X.Id==item.Id);
                   

                    addOrderDetailDto.ImagePath =productDetail.ImagePath ;
                    _orderDetailService.AddOrderDetail(addOrderDetailDto);
                    productDetail.Quantity -= item.Quantity;
                    var editProductDetail = _productDetailService.GetProductDetail(productDetail.Id);
                    _productDetailService.EditProductDetail(editProductDetail);

                var editOrderDto = new EditOrderDto()
                {
                    Id = orderId,
                    TotalPrice = Total,
                    UserId = user.Id,
                    OrderStatu = OrderStatusEnum.SiparisHazırlanıyor
                };
                 _orderService.EditOrder(editOrderDto);

                       

                }
            var TotalQuantity = 0;

            var deleteCart=_cartService.GetAllCarts().FirstOrDefault(X=>X.UserId==user.Id);
            var cartItemList=_cartItemService.GetAllCartItems().Where(x=>x.CartId==deleteCart.Id).ToList();
            foreach(var cartItem in cartItemList)
            {
                _cartItemService.DeleteCartItem(cartItem.Id);
            }

                    return Redirect("Index");

            } 
         
        public IActionResult OrderDetail(int orderId)
        {
          var order=_orderService.GetOrder(orderId);
            var orderDetailList = _orderDetailService.GetAllOrderDetail().Where(x=> x.OrderId == orderId).Select(x => new OrderDetailVm
            {
               Id=x.Id,
               ImagePath= x.ImagePath,
               OrderId = orderId,
               Price = x.Price,
               Quantity = x.Quantity,
               ProductDetailId = x.ProductDetailId,
               VeritansName=x.VeriantName,
               ProductName=x.ProductName,


            }).ToList();
            var TotalPrice =order.TotalPrice;
            
            ViewBag.Status = order.OrderStatu;
            ViewBag.TotalPrice = TotalPrice;    

            return View(orderDetailList);
        }


        }
    }

