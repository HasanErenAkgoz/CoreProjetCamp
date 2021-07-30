using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
    public class Admin : IEntity
    {
        [Key]
        public int Id { get; set; }


        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        [StringLength(10)]
        public string AdminRole { get; set; }
        public bool Status { get; set; }
    }
}
