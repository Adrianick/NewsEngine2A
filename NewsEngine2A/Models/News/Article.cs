using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEngine2A.Models.News
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Headline { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? EditDate { get; set; }

        public string PictureUrl { get; set; }

        public int NewsCategoryId { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User.User User { get; set; }

        [ForeignKey("NewsCategoryId")]
        public virtual NewsCategory NewsCategory { get; set; }

        //public virtual List<Comment> Comments { get; set; }
    }
}