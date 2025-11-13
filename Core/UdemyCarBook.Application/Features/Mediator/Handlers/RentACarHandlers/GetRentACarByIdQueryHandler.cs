using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarDescription;
using UdemyCarBook.Application.Features.Mediator.Results.CommentResults;
using UdemyCarBook.Application.Features.Mediator.Results.RentACarResults;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResults;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarByIdQueryHandler : IRequestHandler<GetRentACarByIdQuery, GetRentACarByIdQueryResult>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarByIdQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetRentACarByIdQueryResult> Handle(GetRentACarByIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetRentACarByIDCarNameLocationNameQuery(request.Id);
            return new GetRentACarByIdQueryResult
            {
                RentACarID = values.RentACarID,
                CarID = values.CarID,
                //CarName = values.Car.Brand.Name + " " + values.Car.Model,
                LocationID = values.LocationID,
               // LocationName = values.Location.Name,
                Avaible = values.Avaible,
            };
        }
    }
}
