using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
   public class About: IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Details { get; set; }
        public string Details2 { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
    }
}
