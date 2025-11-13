using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.RentACarCommands
{
    public class ChangeRentACarAvaibleToTrueCommand : IRequest
    {
        public ChangeRentACarAvaibleToTrueCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
