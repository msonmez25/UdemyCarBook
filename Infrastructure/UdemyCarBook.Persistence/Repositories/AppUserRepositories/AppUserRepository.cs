using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {

        private readonly CarBookContext _context;

        public AppUserRepository(CarBookContext context)
        {
            _context = context;
        }

        public AppUser GetAppUserIdByRoleName(int id)
        {
            var value = _context.AppUsers.Where(x => x.AppUserID == id).Include(x => x.AppRole).FirstOrDefault();
            return value;
        }

        public List<AppUser> GetAppUsersByRoleName()
        {
            var values = _context.AppUsers.Include(x=>x.AppRole).ToList();
            return values;
        }

        public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            var values = await _context.AppUsers.Where(filter).FirstOrDefaultAsync();
            return values;
        }
    }
}
