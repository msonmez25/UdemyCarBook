using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.RentACarCommands
{
    public class CreateRentACarCommand : IRequest
    {
        public int LocationID { get; set; }
        public int CarID { get; set; }
        public bool Avaible { get; set; }
    }
}
