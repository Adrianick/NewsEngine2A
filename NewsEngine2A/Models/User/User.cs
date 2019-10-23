﻿using NewsEngine2A.Models.News;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEngine2A.Models.User
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Index("IX_Email", IsUnique = true)]
        [StringLength(450)]

        [Required]
        public string Email { get; set; }

        [Index("IX_Phone", IsUnique = true)]
        [StringLength(20)]

        [Required]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual List<Article> Articles { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public virtual List<UserRole> UsersRoles { get; set; }
    }
}