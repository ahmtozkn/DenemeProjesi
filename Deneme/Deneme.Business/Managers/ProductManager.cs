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
    public class ProductManager : IProductService
    {
        private readonly IRepository<ProductEntity> _productRepository;
        public ProductManager(IRepository<ProductEntity> productRepository)
        {
                _productRepository = productRepository;
        }
        public int AddProduct(AddProductDto addProductDto)
        {
            var prodcutEntity = new ProductEntity()
            {
                Name = addProductDto.Name,
                ImagePath = addProductDto.ImagePath,
                Price = addProductDto.Price,
               
            };
            _productRepository.Add(prodcutEntity);
            return prodcutEntity.Id;
           
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public void EditProduct(EditProductDto editProductDto)
        {
            var entity =_productRepository.GetById(editProductDto.Id);

            entity.Name = editProductDto.Name;
            entity.ImagePath = editProductDto.ImagePath;
            entity.Price = editProductDto.Price;
                
                

           _productRepository.Update(entity);
          
        }

        public List<ListProductDto> GetAllProducts()
        {
          var listDto=_productRepository.GetAll().Select(X=> new ListProductDto()
          {

              Id = X.Id,
              Name = X.Name,
              ImagePath= X.ImagePath,
              Price = X.Price,
          }).ToList();  
            return listDto;
        }

        public EditProductDto GetProduct(int id)
        {
           var entity=_productRepository.GetById(id);
            var editProductDto = new EditProductDto()
            {   
                Id = entity.Id,
                Name = entity.Name,
                ImagePath = entity.ImagePath,
                Price = entity.Price,


            };
            return editProductDto;
           
        }
    }
}
