using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResult;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarPricingInterface;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithDailyPeriodQueryHandler : IRequestHandler<GetCarPricingWithDailyPeriodQuery, List<GetCarPricingWithDailyPeriodQueryResult>>
    {

        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithDailyPeriodQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithDailyPeriodQueryResult>> Handle(GetCarPricingWithDailyPeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithDailyPeriodCars();
            return values.Select(x => new GetCarPricingWithDailyPeriodQueryResult
            {
              CarID = x.CarID,
              CarPricingID = x.CarPricingID,
              CoverImageUrl = x.Car.CoverImageUrl,
              Brand = x.Car.Brand.Name,
              Model = x.Car.Model,
              Amount = x.Amount,

            }).ToList();


        }
    }
}
