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

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetReservationQueryResult
            {
                ReservationID = x.ReservationID,
                Name = x.Name,
                Surname = x.Surname,
                Age = x.Age,
                DriverLicenseYear = x.DriverLicenseYear,
                CarID = x.CarID,
                DropOffLocationID = x.DropOffLocationID,
                PickUpLocationID = x.PickUpLocationID,
                Email = x.Email,
                Phone = x.Phone,
                Description = x.Description,
                Status = x.Status,
                EndDate = x.EndDate,
                StartDate = x.StartDate,
            }).ToList();
        }
    }
}
