using NewsEngine2A.Models.News;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEngine2A.Models.User
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,50}")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,50}")]
        public string Surname { get; set; }

        [Required]
        [Index("IX_Email", IsUnique = true)]
        [StringLength(450)]
        public string Email { get; set; }

        [Index("IX_Phone", IsUnique = true)]
        [StringLength(20)]

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters and must contain at least 1 number and 1 letter")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual List<Article> Articles { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<UserRole> UsersRoles { get; set; }
    }
}