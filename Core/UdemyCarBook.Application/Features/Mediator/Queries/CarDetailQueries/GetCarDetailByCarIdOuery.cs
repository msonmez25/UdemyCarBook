using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarDetailResults;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureDetailResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarDetailQueries
{
	public class GetCarDetailByCarIdOuery : IRequest<List<GetCarDetailByCarIdOueryResult>>
	{
		public GetCarDetailByCarIdOuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
