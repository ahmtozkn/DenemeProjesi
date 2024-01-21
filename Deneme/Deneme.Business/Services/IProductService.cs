using Deneme.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Services
{
    public  interface IProductService
    {
        int AddProduct(AddProductDto addProductDto);
        void EditProduct(EditProductDto editProductDto);

        void DeleteProduct(int id);

        List<ListProductDto> GetAllProducts(); 

        EditProductDto GetProduct(int id);
      



    }
}
