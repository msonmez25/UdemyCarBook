using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarDescription;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
	public class GetCarDescriptionByIdQuery : IRequest<GetCarDescriptionByIdQueryResult>
	{
		public GetCarDescriptionByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
