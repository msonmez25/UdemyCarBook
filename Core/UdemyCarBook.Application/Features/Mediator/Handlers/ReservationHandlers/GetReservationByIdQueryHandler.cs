using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.ReservationQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Features.Mediator.Results.ReservationResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdQueryResult>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationByIdQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetReservationByIdQueryResult
            {
                ReservationID = values.ReservationID,
                Name = values.Name,
                Surname = values.Surname,
                Age = values.Age,
                DriverLicenseYear = values.DriverLicenseYear,
                CarID = values.CarID,
                DropOffLocationID = values.DropOffLocationID,
                PickUpLocationID = values.PickUpLocationID,
                Email = values.Email,
                Phone = values.Phone,
                Description = values.Description,
                 Status= values.Status,
                 StartDate = values.StartDate,
                 EndDate = values.EndDate
            };
        }
    }
}
