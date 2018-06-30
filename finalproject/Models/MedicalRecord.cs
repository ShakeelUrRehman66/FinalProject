using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalproject.Models
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public string ShortDescription { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
        public string images { get; set; }
        public Patient patient { get; set; }
    }
}
