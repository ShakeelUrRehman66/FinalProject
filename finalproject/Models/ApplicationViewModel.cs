using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalproject.Models
{
    public class ApplicationViewModel
    {
        public Doctor Doctor { get; set; }
        public List<Doctor> Doctors { get; set; }
        public Patient Patient { get; set; }
        public List<Patient> Patients { get; set; }
        public Admin Admin { get; set; }
        public List<Admin> Admins { get; set; }
        public Appointment Appointment { get; set; }
        public List<Appointment> Appointments { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public List<MedicalRecord> MedicalRecords { get; set; }
        public DietPlan DietPlan { get; set; }
        public List<DietPlan> DietPlans { get; set; }
    }
}
