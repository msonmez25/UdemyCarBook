using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureDetailCommands
{
    public class UpdateCarFeatureAvaibleChangeToFalseCommand : IRequest
    {
        public UpdateCarFeatureAvaibleChangeToFalseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
