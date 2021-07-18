using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrate
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public bool Status { get; set; }
        public int BadgeStyleId { get; set; }
        public virtual BadgeStyle BadgeStyle { get; set; }
        public virtual ICollection<Heading> Headings { get; set; }
    }
}