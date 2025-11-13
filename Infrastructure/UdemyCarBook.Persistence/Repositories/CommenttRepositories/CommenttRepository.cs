using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CommenttInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CommenttRepositories
{
    public class CommenttRepository : ICommenttRepository
    {

        private readonly CarBookContext _context;

        public CommenttRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Comment> GetCommentsByBlogCategoryName()
        {
            var values = _context.Comments.Include(x => x.Blog).ThenInclude(y=>y.Category).ToList();
            return values;
        }

        public List<Comment> GetCommettByBlogId(int id)
        {
            var values = _context.Comments.Include(y=>y.Blog).Where(x => x.BlogID == id).ToList();
            return values;
        }

        public int GetCountCommentByBlog(int id)
        {
            var value = _context.Comments.Where(x => x.BlogID == id).Count();
            return value;
        }
    }
}
