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
    public class GetCarCountByTranmissionIsAutoCountQueryHandler : IRequestHandler<GetCarCountByTranmissionIsAutoCountQuery, GetCarCountByTranmissionIsAutoCountQueryResult>
    {

        private readonly IStatisticsRepository _repository;

        public GetCarCountByTranmissionIsAutoCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByTranmissionIsAutoCountQueryResult> Handle(GetCarCountByTranmissionIsAutoCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByTranmissionIsAuto();
            return new GetCarCountByTranmissionIsAutoCountQueryResult
            {
                CarCountByTranmissionIsAutoCount = value,
            };
        }
    }
}
