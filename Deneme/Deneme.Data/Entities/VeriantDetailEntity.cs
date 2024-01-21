using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.Entities
{
    public class VeriantDetailEntity:BaseEntity
    {
        public string Name { get; set; }

        public List<ProductDetailEntity> ProductDetails { get; set; }
    }
    public class VeriantDetailConfiguration : BaseConfiguration<VeriantDetailEntity>
    {

        public override void Configure(EntityTypeBuilder<VeriantDetailEntity> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            base.Configure(builder);
        }
    }

}
