using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.Entities
{
   public abstract class BaseEntity
    {
        public BaseEntity()
        {
               CreateDate = DateTime.Now;
        }
        public int Id { get; set; } 

        public bool IsDeleted { get; set; } 

        public DateTime CreateDate { get; set; }
        
        public DateTime? ModifiedDate { get; set; }
    }
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);

            // Bu veritabanı üzerinde yapılacak bütün sorgulamalarda yukarıdaki linq geçerli olacak. Böylelikle benim silinmemişleri getir diye her defasında ekleme yapmama gerek kalmayacak!

            builder.Property(x => x.ModifiedDate)
                .IsRequired(false);
            // null olabilir.
        }
    }
}
