using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NewsEngine2A.Models.User
{
    public class Role : IdentityRole
    {
        public int Id { get; set; }
        [MaxLength(512)]
        public string Name { get; set; }
    }
}