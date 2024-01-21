using Deneme.Business.Dtos;
using Deneme.Business.Services;
using Deneme.Data.Entities;
using Deneme.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Deneme.WebUI.Controllers
{
    public class CardController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly IVeriantService _veriantService;
        private readonly ICartItemService _cartItemService;
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CardController(IProductDetailService productDetailService,IProductService productService,IVeriantService veriantService,ICartService cartService,ICartItemService cartItemService,UserManager<ApplicationUser> userManager)
        {
            _productDetailService = productDetailService;
            _productService = productService;
            _veriantService = veriantService;
            _cartService = cartService;
            _cartItemService = cartItemService;
            _userManager = userManager;
        }
        public async  Task<IActionResult> Index(string? SepetMessage,int? sepetacma)
        {
            var userEntity = await _userManager.GetUserAsync(User);
            var cartItem = _cartItemService.GetAllCartItems().Where(X=>X.CartId==_cartService.GetAllCarts().FirstOrDefault(X=>X.UserId==userEntity.Id).Id).Select(x => new CartItemVm()
            {
                Id = x.Id,
                ProductDetailId = x.ProductId,
                CartId = x.Id,
                Price = x.Price,
                Quantity = x.Quantity,
                ImagePath = _productService.GetProduct(_productDetailService.GetProductDetail(x.ProductId).ProductId).ImagePath,
                ProductName = _productService.GetProduct(_productDetailService.GetProductDetail(x.ProductId).ProductId).Name,
                VertiansName = _veriantService.GetVeriant((_productDetailService.GetProductDetail(x.ProductId).VeritansDetailId)).Name,
                
                


            }).ToList();
            var TotalPrice = 0;
            var TotalQuantity = 0;
            var cartUser = _cartService.GetAllCarts().FirstOrDefault(x=>x.UserId==userEntity.Id);//Cookies ile
            var cartItemList = _cartItemService.GetAllCartItems().Where(x => x.CartId == cartUser.Id);
            foreach (var item in cartItemList)
            {
                TotalPrice += item.Quantity * (int)item.Price;
                TotalQuantity = TotalQuantity + item.Quantity;
            }
            ViewBag.Price = TotalPrice;
           
        


            var list = _productDetailService.GetAllProductDetail();
            var productVm=list.Select(X=> new ProductDetailVM()
            {
                Id=X.Id,
                ImagePath=X.ImagePath,
                ProductName=X.ProductName,
                ProductId=X.ProductId,
                VeritansDetailId=X.VeritansDetailId,
                VertianName=X.VertianName,
                Quantity = X.Quantity

            }).ToList();
            var listCard = _productService.GetAllProducts().Select(X=> new ShoppingCardVM() {
            Id=X.Id,
            Price=X.Price,
            Name=X.Name,
            ImagePath=X.ImagePath,
            }).ToList();
            ViewBag.ProductVm = listCard;
            ViewBag.ProdcutDetailVm = _productDetailService.GetAllProductDetail().Select(x => new ProductDetailVM()
            {
                Id=x.Id,
                ProductId = x.ProductId,
                VeritansDetailId = x.VeritansDetailId,
                VertianName=x.VertianName
            }).ToList();
            ViewBag.Veritans=_veriantService.GetAllVeriants().ToList();
            ViewBag.SepetMessage = SepetMessage;
            ViewBag.CartItemList = cartItem;
            ViewBag.SepetAcma = sepetacma;
            ViewBag.TotalPrice=TotalPrice;
            ViewBag.TotalQuantity=TotalQuantity;
            return View();
        }
        public IActionResult SepeteItemDelete(int id)
        {
            _cartItemService.DeleteCartItem(id);
            ViewBag.SepetAcma = 1;
            return View("Index");

        }
            
            
            
    }
}
