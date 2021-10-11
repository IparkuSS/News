using System;
using System.Collections.Generic;

#nullable disable

namespace News.Models
{
    public partial class Section
    {
        public Section()
        {
            Authors = new HashSet<Author>();
            Subsections = new HashSet<Subsection>();
        }

        public int IdSection { get; set; }
        public string NameSection { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Subsection> Subsections { get; set; }
    }
}
