﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Dtos
{
   public  class AddUserDto
    {

        public int Id { get; set; } 

        public string UserName {  get; set; }   

        public string Email {  get; set; }  

        public string Password { get; set; }
    }
}
