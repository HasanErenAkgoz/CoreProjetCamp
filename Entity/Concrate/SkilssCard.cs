using Core.Entities;
using Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
    public class SkilssCard : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Skilss { get; set; }
        public int Value { get; set; }
        public bool Status { get; set; }
 
    }
}
