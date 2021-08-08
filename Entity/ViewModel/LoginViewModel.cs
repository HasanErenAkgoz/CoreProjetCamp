using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModel
{
    public class LoginViewModel
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Persistent { get; set; }
        public bool Lock { get; set; }
    }
}
