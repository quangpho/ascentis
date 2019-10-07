using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        [Required]
        public byte Gender { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string EmailOptIn { get; set; }
    }
}
