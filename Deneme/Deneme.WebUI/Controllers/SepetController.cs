using Deneme.Business.Dtos;
using Deneme.Business.Managers;
using Deneme.Business.Services;
using Deneme.Data.Entities;
using Deneme.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.WebUI.Controllers
{
    public class SepetController : Controller
    {
        private readonly ICartItemService _cartItemService;
        private readonly ICartService _cartService; 
        private readonly IProductDetailService _productDetailService;
        private readonly IProductService _productService;
        private readonly IVeriantService _veriantService;
        private readonly UserManager<ApplicationUser> _userManager;
        public SepetController(ICartItemService cartItemService,ICartService cartService,IProductDetailService productDetailService,IProductService productService,IVeriantService veriantService,UserManager<ApplicationUser> userManager)
        {
                _cartItemService = cartItemService;
                _cartService = cartService;
               _productDetailService = productDetailService;  
               _productService = productService;
            _veriantService = veriantService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        { 
            
            var userEntity = await _userManager.GetUserAsync(User);
         
            if(userEntity is null)
            {

                return RedirectToAction("Login", "Auth");
            }


            var cartItem = _cartItemService.GetAllCartItems().Select(x => new CartItemVm()
            {
                Id = x.Id,
                ProductDetailId = x.ProductId,
                CartId = x.Id,
                Price = x.Price,
                Quantity= x.Quantity,
                ImagePath= _productService.GetProduct(_productDetailService.GetProductDetail(x.ProductId).ProductId).ImagePath,
                ProductName=_productService.GetProduct(_productDetailService.GetProductDetail(x.ProductId).ProductId).Name,
                VertiansName=_veriantService.GetVeriant( (_productDetailService.GetProductDetail(x.ProductId).VeritansDetailId)).Name
                


            }).ToList();
            var TotalPrice = 0;
            var TotalQantity = 0;
           
            var cartUser = _cartService.GetAllCarts().FirstOrDefault(x=>x.UserId==userEntity.Id);
            var cartItemList = _cartItemService.GetAllCartItems().Where(x => x.CartId == cartUser.Id);
           
            foreach(var item in cartItemList)
            {
                TotalPrice += item.Quantity * (int)item.Price;
                TotalQantity = TotalQantity + item.Quantity;
            }
           ViewBag.TotalPrice = TotalPrice;
            ViewBag.TotalCount = TotalQantity;
            return View(cartItem);
        }
        [HttpGet]
        public async Task<IActionResult> Add(ProductForm productForm) 
        { 
            var userEntity = await _userManager.GetUserAsync(User);

            if(userEntity is  null)
            {

                return RedirectToAction("Login", "Auth");


            }

            var productDetail=_productDetailService.GetAllProductDetail().FirstOrDefault(x=>x.ProductId==productForm.Id&&x.VeritansDetailId==productForm.VeritansId);

            if(productDetail == null)
            {

                return RedirectToAction("Index", "Card");
            }

           

          var cartList = _cartService.GetAllCarts().FirstOrDefault(x=>x.UserId==userEntity.Id);//user ile yakalıycaz
            if(cartList is not null)
            {
                var hasCart = _cartItemService.GetAllCartItems().FirstOrDefault(X => X.CartId ==cartList.Id && X.ProductId ==productDetail.Id);
                if(hasCart != null)
                {
                    var editCartıtemDto = new EditCartItemDto()
                    {
                        Id = hasCart.Id,
                        CartId =cartList.Id,
                        Quantity =hasCart.Quantity + 1,
                        Price=hasCart.Price,
                        ProductId= productDetail.Id,
                       


                    };
                    _cartItemService.EditCartItem(editCartıtemDto);
                    var sepetMessage1 = "Ürün Sepete Eklendi";
                    var sepet1 = 1;
                    return RedirectToAction("Index", "Card", new { SepetMessage = sepetMessage1,sepetacma=sepet1 });
                }

                var productDetailDtos = _productDetailService.GetProductDetail(productDetail.Id);
                var productDtos = _productService.GetProduct(productDetailDtos.ProductId);
                var addCartItemDto = new AddCartItemDto()
                {
                    CartId = cartList.Id,
                    Quantity = 1,
                    Price =productDtos.Price,
                    ProductId = productDetail.Id,
                    

              };
                _cartItemService.AddCartItem(addCartItemDto);
              var sepetMessage2 = "Ürün Sepete Eklendi";
                var sepet2 = 1;
                return RedirectToAction("Index", "Card", new {SepetMessage=sepetMessage2,sepetacma=sepet2});

            }

            

            var productDetailDto=_productDetailService.GetProductDetail(productDetail.Id);
            var productDto=_productService.GetProduct(productDetailDto.ProductId);
            var cartDto = new AddCartDto()
            {
                UserId=userEntity.Id,
            };
            var cartId=_cartService.AddCart(cartDto);

            var cartItem = new AddCartItemDto()
            {
                ProductId = productDetailDto.Id,
                CartId = cartId,
                Price = productDto.Price,
                Quantity = 1,

            };       
         _cartItemService.AddCartItem(cartItem);
            var sepetmeseage3 = "Ürün Sepete Eklendi";
            var sepet3 = 1;
            return RedirectToAction("Index", "Card", new { SepetMessage = sepetmeseage3,sepetacma=sepet3 } );
        
        
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userEntity = await _userManager.GetUserAsync(User);
            var cart=_cartService.GetAllCarts().FirstOrDefault(x=>x.UserId == userEntity.Id);

            _cartItemService.DeleteCartItem(id);
            return RedirectToAction("Index", "Sepet");



        }

        public IActionResult Increase(int id)
        {
            var cartItem=_cartItemService.GetCartItem(id);

            var editCartıtemDto = new EditCartItemDto()
            {
                Id = id,
                ProductId = cartItem.ProductId,
                CartId = cartItem.CartId,
                Price = cartItem.Price,
                Quantity = cartItem.Quantity + 1
            };
            _cartItemService.EditCartItem(editCartıtemDto);
            return RedirectToAction("Index", "Sepet");

        }
        public IActionResult Decrease(int id)
        {
            var cartItem = _cartItemService.GetCartItem(id);
            if (cartItem.Quantity == 1)
            {
                _cartItemService.DeleteCartItem(id);
                return RedirectToAction("Index", "Sepet");
            }


            var editCartıtemDto = new EditCartItemDto()
            {
                Id = id,
                ProductId = cartItem.ProductId,
                CartId = cartItem.CartId,
                Price = cartItem.Price,
                Quantity = cartItem.Quantity - 1
            };
            _cartItemService.EditCartItem(editCartıtemDto);
            return RedirectToAction("Index", "Sepet");



        }

    }
}
