using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrate
{
    public class Writer : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Lütfen 50 Karekterden Uzun Veri Girmeyiniz")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Lütfen 50 Karekterden Uzun Veri Girmeyiniz")]
        public string Surname { get; set; }
        public string Image { get; set; }
        [StringLength(50, ErrorMessage = "Lütfen 50 Karekterden Uzun Veri Girmeyiniz")]
        public string Mail { get; set; }
        [StringLength(150, ErrorMessage = "Lütfen 150 Karekterden Uzun Veri Girmeyiniz")]
        public string Password { get; set; }
        public bool Status { get; set; }
        [StringLength(100)]
        public string About { get; set; }
        public virtual ICollection<Heading> Headings { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}
