using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string Title { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public string Description1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public string BigImageUrl { get; set; }

        public List<TagCloud> TagClouds { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
