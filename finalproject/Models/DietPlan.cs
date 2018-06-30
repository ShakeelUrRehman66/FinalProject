using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalproject.Models
{
    public class DietPlan
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string DietName { get; set; }
        public string Description { get; set; }
        [ForeignKey("patientID")]
        public int pateintID { get; set; }
        public Patient Patients { get; set; }
    }
}
