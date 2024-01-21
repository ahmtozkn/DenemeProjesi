using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Deneme.Data.Entities;

namespace Deneme.Data.Context
{
   public class InMemoryContext:DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext>options):base(options) 
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartEntity>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<CartItemEntity>().HasQueryFilter(x => x.IsDeleted == false);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CartEntity> Carts => Set<CartEntity>();

        public DbSet<CartItemEntity> CartItems => Set<CartItemEntity>();
    }
}
