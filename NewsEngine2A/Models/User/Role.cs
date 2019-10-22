using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsEngine2A.Models.User
{
    public class Role
    {
        public int Id { get; set; }
        [MaxLength(512)]
        public string Name { get; set; }
    }
}