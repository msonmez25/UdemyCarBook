using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {

        private readonly IRepository<Reservation> _repository;

        public UpdateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ReservationID);
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.Age = request.Age;
            values.DriverLicenseYear = request.DriverLicenseYear;
            values.Email = request.Email;
            values.Phone = request.Phone;
            values.PickUpLocationID = request.PickUpLocationID;
            values.DropOffLocationID = request.DropOffLocationID;
            values.CarID = request.CarID;
            values.Description = request.Description;
            values.StartDate = request.EndDate;
            values.Description = request.Description;
            await _repository.UpdateAsync(values);
        }
    }
}
