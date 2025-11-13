using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Interfaces.ReservationInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class ChangeReservationStatusToCancaledCommandHandler : IRequestHandler<ChangeReservationStatusToCancaledCommand>
    {
        private readonly IReservationRepository _repository;

        public ChangeReservationStatusToCancaledCommandHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeReservationStatusToCancaledCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeReservationStatusToCancaled(request.Id);
        }
    }
}
