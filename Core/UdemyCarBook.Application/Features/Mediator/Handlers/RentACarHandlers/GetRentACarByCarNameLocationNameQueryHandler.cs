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
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarByCarNameLocationNameQueryHandler : IRequestHandler<GetRentACarByCarNameLocationNameQuery,List<GetRentACarByCarNameLocationNameQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarByCarNameLocationNameQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarByCarNameLocationNameQueryResult>> Handle(GetRentACarByCarNameLocationNameQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetRentACarByCarNameLocationNameQuery();
            return values.Select(x => new GetRentACarByCarNameLocationNameQueryResult
            {
                RentACarID = x.RentACarID,
                CarID = x.CarID,
                CarName = x.Car.Brand.Name + " " + x.Car.Model,
                LocationID = x.LocationID,
                LocationName = x.Location.Name,
                Avaible = x.Avaible,
               
            }).ToList();
        }
    }
}
