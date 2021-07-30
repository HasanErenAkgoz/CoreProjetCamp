
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
