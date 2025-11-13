using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries
{
    public class GetContactByIdQuey
    {
        public GetContactByIdQuey(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
