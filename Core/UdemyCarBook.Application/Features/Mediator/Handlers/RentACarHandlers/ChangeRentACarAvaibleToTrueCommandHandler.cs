using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.RentACarCommands;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class ChangeRentACarAvaibleToTrueCommandHandler : IRequestHandler<ChangeRentACarAvaibleToTrueCommand>
    {
        private readonly IRentACarRepository _repository;

        public ChangeRentACarAvaibleToTrueCommandHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeRentACarAvaibleToTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeRentACarAvaibleToTrue(request.Id);
        }
    }
}
