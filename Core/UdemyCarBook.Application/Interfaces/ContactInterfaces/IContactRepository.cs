using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces.ContactInterfaces
{
    public interface IContactRepository
    {
        void ChangeStatusTrue(int id);
        void ChangeStatusFalse(int id);
    }
}
