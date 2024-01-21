using Deneme.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.Context
{
   public class DenemeContext:IdentityDbContext<ApplicationUser>
    {
        public DenemeContext(DbContextOptions<DenemeContext>options):base(options) 
        {
           

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailConfiguration());
            modelBuilder.ApplyConfiguration(new VeriantDetailConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ProductEntity> Products=>Set<ProductEntity>(); 
        public DbSet<ProductDetailEntity>ProductDetails=>Set<ProductDetailEntity>();    
        public DbSet<VeriantDetailEntity>VeritantDetails=>Set<VeriantDetailEntity>();   

        public DbSet<OrderEntity> Orders=>Set<OrderEntity>(); 

        public DbSet<OrderDetailEntity> OrderDetails=>Set<OrderDetailEntity>();
    }
}
