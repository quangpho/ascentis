using System;
using System.ComponentModel.DataAnnotations;

namespace Ascentis.DAL.Model
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [Phone]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public byte Gender { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DOB { get; set; }

        public string EmailOptIn { get; set; }
    }
}
