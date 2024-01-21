using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.Entities
{
    public class ProductEntity:BaseEntity
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public decimal? Price { get; set; }

        public List<ProductDetailEntity> ProductDetails { get; set; }
    }
    public class ProductConfiguration : BaseConfiguration<ProductEntity>
    {

        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            base.Configure(builder);
        }
    }
}
