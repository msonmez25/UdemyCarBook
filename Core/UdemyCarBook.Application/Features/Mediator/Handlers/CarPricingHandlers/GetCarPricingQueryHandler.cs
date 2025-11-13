using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResult;
using UdemyCarBook.Application.Features.Mediator.Results.VitesResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingQueryHandler :IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
    {
        private readonly IRepository<CarPricing> _repository;

        public GetCarPricingQueryHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarPricingQueryResult
            {
                CarPricingID = x.CarPricingID,
               PricingID = x.PricingID,
               CarID = x.CarID,
               Amount = x.Amount               
            }).ToList();
        }
    }
}
