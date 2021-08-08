using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModel
{
   public class EditUserViewModel:RegisterViewModel
    {
        public IFormFile ImagePath { get; set; }

    }
}
