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
    public class ChangeReservationStatusToReservationReceiptCommandHandler : IRequestHandler<ChangeReservationStatusToReservationReceiptCommand>
    {
        private readonly IReservationRepository _repository;

        public ChangeReservationStatusToReservationReceiptCommandHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeReservationStatusToReservationReceiptCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeReservationStatusToReservationReceipt(request.Id);
        }
    }
}
