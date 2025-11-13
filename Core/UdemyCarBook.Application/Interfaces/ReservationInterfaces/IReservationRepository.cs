using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces.ReservationInterfaces
{
    public interface IReservationRepository
    {
        void ChangeReservationStatusToApproved(int id);
        void ChangeReservationStatusToCancaled(int id);
        void ChangeReservationStatusToReservationReceipt(int id);
    }
}
