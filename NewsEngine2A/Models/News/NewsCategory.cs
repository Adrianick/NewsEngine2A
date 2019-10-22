using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEngine2A.Models.News
{
    public class NewsCategory
    {
        public int Id { get; set; }

        [Index("IX_Name", IsUnique = true)]
        [StringLength(450)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}