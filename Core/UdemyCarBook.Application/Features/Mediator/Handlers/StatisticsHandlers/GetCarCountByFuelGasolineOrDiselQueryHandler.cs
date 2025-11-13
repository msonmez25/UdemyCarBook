using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByFuelGasolineOrDiselQueryHandler : IRequestHandler<GetCarCountByFuelGasolineOrDiselQuery, GetCarCountByFuelGasolineOrDiselQueryResult>
    {

        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelGasolineOrDiselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }


        public async Task<GetCarCountByFuelGasolineOrDiselQueryResult> Handle(GetCarCountByFuelGasolineOrDiselQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelGasolineOrDisel();
            return new GetCarCountByFuelGasolineOrDiselQueryResult
            {
                CarCountByFuelGasolineOrDisel = value,
            };
        }
    }
}
