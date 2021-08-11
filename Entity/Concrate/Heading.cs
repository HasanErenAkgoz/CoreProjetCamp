using Core.Entities;
using Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrate
{
    public class Heading : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int? CategoryId { get; set; }
        public int? WriterId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Writer Writer { get; set; }
        public virtual ICollection<Content> Contents { get; set; }

    }
}
