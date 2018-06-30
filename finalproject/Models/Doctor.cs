using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalproject.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string Name { get; set; }
        [StringLength(11, MinimumLength = 11)]
        public string CNIC { get; set; }
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password Donot Match")]
        public string ConfirmPassword { get; set; }
        public string PasswordResetToken { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }
        public string Hospital { get; set; }
        public string Role {get;set;}
        public string Timings { get; set; }
        [NotMapped]
        public IFormFile userimage { get; set; }
        public string userimages { get; set; }
        public Appointment appointments { get; set; }
    }
}
