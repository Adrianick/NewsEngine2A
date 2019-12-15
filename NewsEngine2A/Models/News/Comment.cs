using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEngine2A.Models.News
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string AuthorId { get; set; }
        public int ArticleId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User.User User { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

    }
}