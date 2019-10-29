using System;
using Microsoft.AspNet.Identity.EntityFramework;
using NewsEngine2A.Models.News;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEngine2A.Models.User
{
    public class User : IdentityUser
    {
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [Index("IX_Email", IsUnique = true)]
        [StringLength(450)]
        public string Email { get; set; }

        [Index("IX_Phone", IsUnique = true)]
        [StringLength(20)]

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<UserRole> UsersRoles { get; set; }
    }


}