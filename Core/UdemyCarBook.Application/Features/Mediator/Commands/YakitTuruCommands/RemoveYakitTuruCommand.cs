using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.YakitTuruCommands
{
    public class RemoveYakitTuruCommand : IRequest
    {
        public RemoveYakitTuruCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
