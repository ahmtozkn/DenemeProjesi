using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Data.Entities
{
    public class ApplicationUser:IdentityUser
    {
       
      public List<CartEntity> Carts { get; set; }
    public List<OrderEntity> Orders { get; set; }
    }
}
