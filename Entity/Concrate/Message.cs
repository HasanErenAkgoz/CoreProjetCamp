using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
   public class Message:IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string sender { get; set; }
        [StringLength(50)]
        public string Receiver { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
