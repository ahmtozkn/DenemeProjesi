using Deneme.Business.Dtos;
using Deneme.Business.Services;
using Deneme.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;

namespace Deneme.WebUI.Controllers
{  
    
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _environment;
      
        public ProductController(IProductService productService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _environment = environment; 

        }
        public IActionResult Index()
        {
            var productVm = _productService.GetAllProducts().Select(X => new ListProductVm()
            {
                Id = X.Id,
                Name = X.Name,
                ImagePath=X.ImagePath,
                Price= X.Price,
               

            }).ToList();
            return View(productVm);
        }
        [HttpGet]
        public IActionResult Add()
        {
            
         return View(new ProductVM());
        }

        [HttpPost]
        public IActionResult Save(ProductVM productVM) 
        {

          
            var newFileName = "";
            if (productVM.File is not null)
            {

                var allowedFileTypes = new string[] { "image/jpeg", "image/jpg", "image/png", "image/jfif" };


                var allowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png", ".jfif" };


                var fileContentType = productVM.File.ContentType;

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(productVM.File.FileName);

                var fileExtension = Path.GetExtension(productVM.File.FileName);

                if (!allowedFileTypes.Contains(fileContentType) ||
                    !allowedFileExtensions.Contains(fileExtension))
                {
                    ViewBag.FileError = "Dosya formatı veya içeriği hatalı";


               
                    return View("Add", productVM);

                }

                newFileName = fileNameWithoutExtension + "-" + Guid.NewGuid() + fileExtension;


                var folderPath = Path.Combine("images", "products");


                var wwwrootFolderPath = Path.Combine(_environment.WebRootPath, folderPath);


                var wwwrootFilePath = Path.Combine(wwwrootFolderPath, newFileName);


                Directory.CreateDirectory(wwwrootFolderPath);

                using (var fileStream = new FileStream(
                    wwwrootFilePath, FileMode.Create))
                {
                    productVM.File.CopyTo(fileStream);
                }



            }




            if (productVM.Id!=0)
            {
                var editProductDto = new EditProductDto()
                {
                    Id = productVM.Id,
                    Name = productVM.Name,
                    ImagePath = newFileName,
                    Price = productVM.Price,
                };
             _productService.EditProduct(editProductDto);
              return RedirectToAction("Index", "Product");
            }
            var hasProduct=_productService.GetAllProducts().FirstOrDefault(X=>X.Name == productVM.Name);
          
            if(hasProduct!=null)
            {
                ViewBag.Eror = "Böyle Bir Ürün Zaten Mevcut";
               
                return View("Add");

            }
        var addProdcutDto = new AddProductDto()
            {
             Name = productVM.Name,
             ImagePath = newFileName,
             Price= productVM.Price,
             
        };
         _productService.AddProduct(addProdcutDto);
         return RedirectToAction("Index","Product");
        }

        public IActionResult Update(int id)
        {
         var updateProduct=_productService.GetProduct(id);
         var productVm = new ProductVM()
          {
                Id = id,
                Name = updateProduct.Name,
               Price= updateProduct.Price,
         };
            ViewBag.ImagePath = updateProduct.ImagePath;
            return View("Add",productVm);

        }
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
