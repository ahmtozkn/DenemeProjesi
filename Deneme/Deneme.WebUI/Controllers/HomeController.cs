using Deneme.Business.Dtos;
using Deneme.Business.Services;
using Deneme.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.WebUI.Controllers
{ 
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly IVeriantService _veriantService;

       
        public HomeController(IProductDetailService productDetailService,IProductService productService,IVeriantService veriantService)
        {
               _productDetailService = productDetailService;
               _veriantService = veriantService;
               _productService = productService;    
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Veritans=_veriantService.GetAllVeriants();
            ViewBag.Product=_productService.GetAllProducts();
            return View();
        }
           [HttpPost]
          public IActionResult Index(ProductDetailVM productDetailVM)
         {
           if(productDetailVM.Id != 0) 
            {
                var editProductDetailDto = new EditProductDetailDto()
                {
                    Id = productDetailVM.Id,
                   
                    ProductId = productDetailVM.ProductId,
                    Quantity = productDetailVM.Quantity,
                    VeritansDetailId = productDetailVM.VeritansDetailId,
                };
                _productDetailService.EditProductDetail(editProductDetailDto);
                return RedirectToAction("List");
            
            }

           
            var hasProductVeritans=_productDetailService.GetAllProductDetail().FirstOrDefault(x=>x.ProductId==productDetailVM.ProductId&&x.VeritansDetailId==productDetailVM.VeritansDetailId);

            if (hasProductVeritans != null)
            {
                ViewBag.Eror="Böyle Bir Ürün Zaten Mevcut";

                ViewBag.Veritans = _veriantService.GetAllVeriants();
                ViewBag.Product = _productService.GetAllProducts();

                return View("Index");
            }



            var productDetail = new AddProductDetailDto()
            {
                VeritansDetailId = productDetailVM.VeritansDetailId,
                ProductId = productDetailVM.ProductId,
                Quantity = productDetailVM.Quantity,
                
            };
            _productDetailService.AddProductDetail(productDetail);
            return RedirectToAction("List","Home");

        }

        public IActionResult List() 
        {
            var productDetailVm = _productDetailService.GetAllProductDetail().Select(x => new ProductDetailVM()
            {
                Id = x.Id,
                ProductId=x.ProductId,
                Quantity = x.Quantity,
               Price=x.Price,
                VertianName = x.VertianName,
                ProductName = x.ProductName,


            }).ToList();

            return View(productDetailVm);
        }
        public IActionResult Delete(int id) 
        {
          _productDetailService.DeleteProductDetail(id);
           
           return RedirectToAction("List","Home");    
        
        }
         
        public IActionResult Update(int id)
        {
          var updateProduct=_productDetailService.GetProductDetail(id);
            var productDetailVm = new ProductDetailVM()
            {
                Id= id,
              
                Quantity=updateProduct.Quantity,
                ProductId=updateProduct.ProductId,
                VeritansDetailId=updateProduct.VeritansDetailId,    


            };
            ViewBag.Veritans = _veriantService.GetAllVeriants();
            ViewBag.Product = _productService.GetAllProducts();
            return View("Index",productDetailVm);

        }
    }
}
