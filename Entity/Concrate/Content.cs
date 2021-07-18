using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
  public class Content:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }
        public int WritersId { get; set; }
        public virtual Writer Writer { get; set; }
        public bool Status { get; set; }
    }
}
