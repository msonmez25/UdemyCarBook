using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarDescription;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
	public class GetCarDescriptionByCarIdQuery: IRequest<List<GetCarDescriptionByCarIdQueryResult>>
	{
		public GetCarDescriptionByCarIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
