using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalproject.Models
{
    public class Patient
    {
        
        [Key]
        [Display(Name ="Patient ID")]
        public int PId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CNIC { get; set; }

        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public int Password { get; set; }
        [Compare("Password", ErrorMessage = "Password Donot Match")]
        public string ConfirmPassword { get; set; }
        public string Disease { get; set; }
        public string Role { get; set; }
        public string PasswordResetToken { get; set; }
        [NotMapped]
        public IFormFile userimage { get; set; }
        public string userimages { get; set; }

        public Appointment appointments { get; set; }
    }
}
