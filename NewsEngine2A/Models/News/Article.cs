using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEngine2A.Models.News
{
    public class Article
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The article should have a title.")]
        [MinLength(4)]
        [MaxLength(55)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The article should have a headline.")]
        [MinLength(4)]
        [MaxLength(55)]
        public string Headline { get; set; }

        [Required(ErrorMessage = "The article should have content.")]
        [MinLength(4)]
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

        public virtual ICollection<Comment> Comments { get; set; }
    }
}