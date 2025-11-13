using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.AppUserResults
{
    public class GetAppUserByIdQueryResult
    {
        public int AppUserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AppRoleID { get; set; }
        public string AppRoleName { get; set; }
    }
}
