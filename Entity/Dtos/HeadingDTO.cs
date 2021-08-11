using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Dtos
{
    public class HeadingDTO : IDto
    {


        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string CategoryName { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
        public string WriterImage { get; set; }
        public int WriterId { get; set; }
        public string BadgeStyle { get; set; }

    }
}
