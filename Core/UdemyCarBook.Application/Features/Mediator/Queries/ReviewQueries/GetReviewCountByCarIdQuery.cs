using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries
{
	public class GetReviewCountByCarIdQuery : IRequest<GetReviewCountByCarIdQueryResult>
	{
		public GetReviewCountByCarIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
