using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureDetailQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureDetailResults;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureDetailInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureDetailHandlers
{
    public class GetCarFeatureDetailByCarIdQueryHandler : IRequestHandler<GetCarFeatureDetailByCarIdQuery, List<GetCarFeatureDetailByCarIdQueryResult>>
    {

        private readonly ICarFeatureDetailRepository _repository;

        public GetCarFeatureDetailByCarIdQueryHandler(ICarFeatureDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureDetailByCarIdQueryResult>> Handle(GetCarFeatureDetailByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarFeatureDetailByCarId(request.Id);
            return values.Select(x => new GetCarFeatureDetailByCarIdQueryResult
            {
                Available = x.Available,
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                FeatureName = x.Feature.Name
            }).ToList();

        }
    }
}
