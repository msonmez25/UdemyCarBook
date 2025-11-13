using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        //Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);
        Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);

        List<AppUser> GetAppUsersByRoleName();
        AppUser GetAppUserIdByRoleName(int id);
    }
}
