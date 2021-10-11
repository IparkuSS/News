using System;
using System.Collections.Generic;

#nullable disable

namespace News.Models
{
    public partial class Author
    {
        public Author()
        {
            Articles = new HashSet<Article>();
        }

        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] Document { get; set; }
        public int? IdSection { get; set; }

        public virtual Section IdSectionNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
