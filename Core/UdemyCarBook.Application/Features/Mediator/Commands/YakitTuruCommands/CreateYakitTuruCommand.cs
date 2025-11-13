using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.YakitTuruCommands
{
    public class CreateYakitTuruCommand : IRequest
    {
        public string Name { get; set; }
    }
}
