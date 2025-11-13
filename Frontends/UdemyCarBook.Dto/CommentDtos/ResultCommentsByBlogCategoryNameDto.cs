using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CommentDtos
{
    public class ResultCommentsByBlogCategoryNameDto
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

        public int BlogID { get; set; }
        public string BlogName { get; set;}
        public string BlogCategoryName { get; set;}
    }
}
