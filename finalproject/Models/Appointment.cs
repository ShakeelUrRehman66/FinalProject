using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalproject.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }
    }
}
