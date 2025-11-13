using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands
{
    public class ChangeReservationStatusToCancaledCommand : IRequest
    {
        public ChangeReservationStatusToCancaledCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
