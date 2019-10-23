using System.ComponentModel.DataAnnotations;

namespace NewsEngine2A.Models.User
{
    public class UserRegister
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [StringLength(450)]

        [Required]
        public string Email { get; set; }

        [StringLength(20)]

        [Required]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}