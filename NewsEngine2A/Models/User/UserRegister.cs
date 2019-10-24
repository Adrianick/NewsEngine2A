using System.ComponentModel.DataAnnotations;

namespace NewsEngine2A.Models.User
{
    public class UserRegister
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,50}", ErrorMessage = "Not a valid Name")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,50}", ErrorMessage = "Not a valid Surname")]
        public string Surname { get; set; }

        [Required]
        [StringLength(450)]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters and must contain at least 1 number and 1 letter")]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}