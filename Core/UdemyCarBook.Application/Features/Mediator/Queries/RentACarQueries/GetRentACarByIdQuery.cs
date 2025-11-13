using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.RentACarResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarByIdQuery : IRequest<GetRentACarByIdQueryResult>
    {
        public GetRentACarByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
