using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.Entities
{
   public  class ProductDetailEntity:BaseEntity
    {
        

        public int ProductId { get; set; }

        public int VeriantDetailId {  get; set; }  

     

        public int Quantity {  get; set; }

        public ProductEntity Product { get; set; }

        public VeriantDetailEntity VeriantDetail { get; set; }

        public List<CartItemEntity> CartItems { get; set; }

        public List<OrderDetailEntity> OrderDetails { get; set; }

    }
    public class ProductDetailConfiguration : BaseConfiguration<ProductDetailEntity>
    {

        public override void Configure(EntityTypeBuilder<ProductDetailEntity> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            base.Configure(builder);
        }
    }
}
