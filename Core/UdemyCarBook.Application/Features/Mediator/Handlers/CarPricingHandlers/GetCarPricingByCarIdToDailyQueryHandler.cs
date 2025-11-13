using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResult;
using UdemyCarBook.Application.Interfaces.CarPricingInterface;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingByCarIdToDailyQueryHandler : IRequestHandler<GetCarPricingByCarIdToDailyQuery, List<GetCarPricingByCarIdToDailyResult>>
    {

        private readonly ICarPricingRepository _repository;

        public GetCarPricingByCarIdToDailyQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingByCarIdToDailyResult>> Handle(GetCarPricingByCarIdToDailyQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingByCarIdToDaily(request.Id);
            return values.Select(x => new GetCarPricingByCarIdToDailyResult
            {
                CarPricingID = x.CarPricingID,
                Amount = x.Amount,
                PricingID = x.PricingID,
                CarID = x.CarID,
                PricingName = x.Pricing.Name

            }).ToList();
        }
    }
}
