﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Dtos
{
   public  class EditProductDto
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public decimal? Price { get; set; }
    }
}
