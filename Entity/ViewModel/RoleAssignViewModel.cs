using Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModel
{
    public class RoleAssignViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool HasAssign { get; set; }
    }
}
