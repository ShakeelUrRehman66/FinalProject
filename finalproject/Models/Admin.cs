using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalproject.Models
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(11,MinimumLength =11)]
        public string CNIC { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password Donot Match")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public string Passwordresettoken { get; set; }
        [NotMapped]
        public IFormFile userimage { get; set; }
        public string userimages { get; set; }
    }
}
