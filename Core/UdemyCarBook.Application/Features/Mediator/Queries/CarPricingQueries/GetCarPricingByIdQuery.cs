using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResult;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingByIdQuery : IRequest<GetCarPricingByIdQueryResult>
    {
        public GetCarPricingByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
