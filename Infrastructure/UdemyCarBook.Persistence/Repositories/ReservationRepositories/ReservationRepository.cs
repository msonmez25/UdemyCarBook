using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.ReservationInterfaces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.ReservationRepositories
{
    public class ReservationRepository : IReservationRepository
    {

        private readonly CarBookContext _context;

        public ReservationRepository(CarBookContext context)
        {
            _context = context;
        }

        public void ChangeReservationStatusToApproved(int id)
        {
            var values = _context.Reservations.Where(x => x.ReservationID == id).FirstOrDefault();
            values.Status = "Onaylandı";
            _context.SaveChanges();
        }

        public void ChangeReservationStatusToCancaled(int id)
        {
            var values = _context.Reservations.Where(x => x.ReservationID == id).FirstOrDefault();
            values.Status = "İptal Edildi";
            _context.SaveChanges();
        }

        public void ChangeReservationStatusToReservationReceipt(int id)
        {
            var values = _context.Reservations.Where(x => x.ReservationID == id).FirstOrDefault();
            values.Status = "Rezervasyon Alındı";
            _context.SaveChanges();
        }
    }
}
