using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrate
{
    public class Contact : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Lütfen 50 Karekterden Uzun Veri Girmeyiniz")]
        public string Email { get; set; }
        [StringLength(50, ErrorMessage = "Lütfen 50 Karekterden Uzun Veri Girmeyiniz")]
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
    }
}
