using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarDetailQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarDetailResults;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureDetailResults;
using UdemyCarBook.Application.Interfaces.CarFeatureDetailInterfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarDetailHandlers
{
	public class GetCarDetailByCarIdOueryHandler : IRequestHandler<GetCarDetailByCarIdOuery, List<GetCarDetailByCarIdOueryResult>>
	{

		private readonly ICarRepository _repository;

		public GetCarDetailByCarIdOueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarDetailByCarIdOueryResult>> Handle(GetCarDetailByCarIdOuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarDetailListByCarID(request.Id);
			return values.Select(x => new GetCarDetailByCarIdOueryResult
			{
				BrandName = x.Brand.Name,
				BrandID = x.BrandID,
				BigImageUrl = x.BigImageUrl,
				CarID = x.CarID,
				CoverImageUrl = x.CoverImageUrl,
				Km = x.Km,
				Luggage = x.Luggage,
				Model = x.Model,
				Seat = x.Seat,
				Year = x.Year,
				YakitTuruID = x.YakitTuruID,
				YakitTuruName = x.YakitTuru.Name,
				VitesID = x.VitesID,
				VitesName = x.Vites.Name,
				CarScore = x.CarScore

			}).ToList();
		}
	}
}
