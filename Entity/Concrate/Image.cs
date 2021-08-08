
using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrate
{
    public class Image : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime? ImageDate { get; set; }
    }
}
