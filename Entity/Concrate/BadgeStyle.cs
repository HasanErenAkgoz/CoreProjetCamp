using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrate
{
    public class BadgeStyle : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
