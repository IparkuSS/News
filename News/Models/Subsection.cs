using System;
using System.Collections.Generic;

#nullable disable

namespace News.Models
{
    public partial class Subsection
    {
        public Subsection()
        {
            Articles = new HashSet<Article>();
        }

        public int IdSubsectionNews { get; set; }
        public string NameSubsection { get; set; }
        public int IdSection { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }

        public virtual Section IdSectionNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
