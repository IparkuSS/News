using System;
using System.Collections.Generic;

#nullable disable

namespace News.Models
{
    public partial class Article
    {
        public int IdArticle { get; set; }
        public int IdSubsectionNews { get; set; }
        public int? IdAuthor { get; set; }
        public string ShortDescription { get; set; }
        public int Priority { get; set; }
        public byte[] ImageArticle { get; set; }
        public DateTime? AddTime { get; set; }
        public string Text { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
        public virtual Subsection IdSubsectionNewsNavigation { get; set; }
    }
}
