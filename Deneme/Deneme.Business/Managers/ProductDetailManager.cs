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
    public class ProductDetailManager : IProductDetailService
    {
        private readonly IRepository<ProductDetailEntity> _productDetailRepository;
        public ProductDetailManager(IRepository<ProductDetailEntity> productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }
        public void AddProductDetail(AddProductDetailDto addProductDetailDto)
        {
            var productDetailEntity = new ProductDetailEntity()
            {
                ProductId = addProductDetailDto.ProductId,
                VeriantDetailId = addProductDetailDto.VeritansDetailId,
                Quantity = addProductDetailDto.Quantity,
             


            };
            _productDetailRepository.Add(productDetailEntity);


        }

        public void DeleteProductDetail(int id)
        {
            _productDetailRepository.Delete(id);
        }

        public void EditProductDetail(EditProductDetailDto editProductDetailDto)
        {
          var editProductDetailEntity=  _productDetailRepository.Get(x=>x.Id==editProductDetailDto.Id);
            
           editProductDetailEntity.ProductId = editProductDetailDto.ProductId;
            editProductDetailEntity.VeriantDetailId = editProductDetailDto.VeritansDetailId;
            editProductDetailEntity.Quantity = editProductDetailDto.Quantity;
          
            _productDetailRepository.Update(editProductDetailEntity);

        }

        public List<ListProductDetailDto> GetAllProductDetail()
        {
           var productDetailDto=_productDetailRepository.GetAll().Select(x=> new ListProductDetailDto()
           {
               Id= x.Id,
               ProductId= x.ProductId,
               Quantity= x.Quantity,
               VeritansDetailId= x.VeriantDetailId,
               VertianName=x.VeriantDetail.Name,
               ProductName=x.Product.Name,
               ImagePath=x.Product.ImagePath,
               Price=x.Product.Price,
               
               

           }).ToList();
            return productDetailDto;
        }

        public EditProductDetailDto GetProductDetail(int id)
        {
            var editProdcutDetailEntity= _productDetailRepository.GetById(id);
            

            var editProductDetailDto = new EditProductDetailDto()
            {

                Id = id,
                ProductId = editProdcutDetailEntity.ProductId,
                Quantity = editProdcutDetailEntity.Quantity,
                VeritansDetailId = editProdcutDetailEntity.VeriantDetailId,
               
            };

            return editProductDetailDto;
        }
    }
}
