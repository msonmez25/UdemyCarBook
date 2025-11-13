using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarDescription;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarBook.Application.Interfaces.CarDescriptionInterfaces;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _repository;

		public GetReviewByCarIdQueryHandler(IReviewRepository repository)
		{
			_repository = repository;
		}


		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetReviewByCarId(request.Id);
			return values.Select(x => new GetReviewByCarIdQueryResult
			{
				ReviewID = x.ReviewID,
				CarID = x.CarID,
				CustomerName = x.CustomerName,
				CustomerImage = x.CustomerImage,
				Comment = x.Comment,
				ReviewDate = x.ReviewDate,
				RaytingValue = x.RaytingValue
			}).ToList();
		}
	}
}
