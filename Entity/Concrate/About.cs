using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrate
{
    public class About : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        public string Details { get; set; }
        public string Details2 { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
    }
}
