using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalproject.Models
{
    public class DiseaseHistory
    {
        [Key]
        public int DisHisID { get; set; }
        public string DiseaseName { get; set; }
        public string Type { get; set; }
        public string duration { get; set; }
        [ForeignKey("patientId")]
        public int patientId { get; set; }
        public Patient patient { get; set; }
    }

}
