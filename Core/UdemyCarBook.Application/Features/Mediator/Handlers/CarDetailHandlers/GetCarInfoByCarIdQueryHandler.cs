using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Features.Mediator.Queries.CarDetailQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarDetailResults;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureDetailResults;
using UdemyCarBook.Application.Interfaces.CarDescriptionInterfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureDetailInterfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarDetailHandlers
{
	public class GetCarInfoByCarIdQueryHandler : IRequestHandler<GetCarInfoByCarIdQuery, GetCarInfoByCarIdQueryResult>
	{
        private readonly ICarRepository _repository;

        public GetCarInfoByCarIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarInfoByCarIdQueryResult> Handle(GetCarInfoByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetCarInfoByCarId(request.Id);
            return new GetCarInfoByCarIdQueryResult
            {
                BigImageUrl = values.BigImageUrl,
                BrandID = values.BrandID,
                BrandName = values.Brand.Name,
                CarID = values.CarID,
                CoverImageUrl = values.CoverImageUrl,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Seat = values.Seat,
                Year = values.Year,
                VitesID = values.VitesID,
                VitesName=values.Vites.Name,
                YakitTuruID = values.YakitTuruID,
                YakitTuruName = values.YakitTuru.Name,
                CarScore = values.CarScore
            };
        }
    }
}
