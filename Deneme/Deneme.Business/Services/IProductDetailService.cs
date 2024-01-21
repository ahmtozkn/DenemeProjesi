using Deneme.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Services
{
   public  interface IProductDetailService
    {
        void AddProductDetail(AddProductDetailDto addProductDetailDto);
        void EditProductDetail(EditProductDetailDto editProductDetailDto);
        List<ListProductDetailDto> GetAllProductDetail();
        void DeleteProductDetail(int id);   
        EditProductDetailDto GetProductDetail(int id);

        
    }
}
