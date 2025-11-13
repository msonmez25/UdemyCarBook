using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CommenttInterfaces
{
    public interface ICommenttRepository
    {
        public List<Comment> GetCommettByBlogId(int id);
        public List<Comment> GetCommentsByBlogCategoryName();

        int GetCountCommentByBlog(int id);
    }
}
