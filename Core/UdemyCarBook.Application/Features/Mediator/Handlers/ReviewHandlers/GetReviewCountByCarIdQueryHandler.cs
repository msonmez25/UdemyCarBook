using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewCountByCarIdQueryHandler : IRequestHandler<GetReviewCountByCarIdQuery, GetReviewCountByCarIdQueryResult>
	{

		private readonly IReviewRepository _repository;

		public GetReviewCountByCarIdQueryHandler(IReviewRepository repository)
		{
			_repository = repository;
		}


		public async Task<GetReviewCountByCarIdQueryResult> Handle(GetReviewCountByCarIdQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetReviewCountByCarId(request.Id);
			return new GetReviewCountByCarIdQueryResult
			{
				CarID = request.Id,
				ReviewCount = value,
			};
		}
	}
}
