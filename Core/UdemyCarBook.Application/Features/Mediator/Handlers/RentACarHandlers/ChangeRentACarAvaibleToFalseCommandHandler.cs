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
    public class ChangeRentACarAvaibleToFalseCommandHandler : IRequestHandler<ChangeRentACarAvaibleToFalseCommand>
    {
        private readonly IRentACarRepository _repository;

        public ChangeRentACarAvaibleToFalseCommandHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeRentACarAvaibleToFalseCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeRentACarAvaibleToFalse(request.Id);
        }
    }
}
