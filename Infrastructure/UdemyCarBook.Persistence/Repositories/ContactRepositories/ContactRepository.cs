using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.ContactInterfaces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.ContactRepositories
{
    public class ContactRepository  : IContactRepository
    {
        private readonly CarBookContext _context;

        public ContactRepository(CarBookContext context)
        {
            _context = context;
        }

        public void ChangeStatusFalse(int id)
        {
            var values = _context.Contacts.FirstOrDefault(x => x.ContactID == id);
            if (values != null)
            {
                values.Status = false;
                _context.SaveChanges();
            }
        }

        public void ChangeStatusTrue(int id)
        {
            var values = _context.Contacts.FirstOrDefault(x => x.ContactID == id);
            if (values != null)
            {
                values.Status = true;
                _context.SaveChanges();
            }
        }
    }
}
