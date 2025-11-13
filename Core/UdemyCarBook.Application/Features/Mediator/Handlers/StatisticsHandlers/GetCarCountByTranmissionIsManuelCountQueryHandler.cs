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
    public class GetCarCountByTranmissionIsManuelCountQueryHandler : IRequestHandler<GetCarCountByTranmissionIsManuelCountQuery, GetCarCountByTranmissionIsManuelCountQueryResult>
    {

        private readonly IStatisticsRepository _repository;

        public GetCarCountByTranmissionIsManuelCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByTranmissionIsManuelCountQueryResult> Handle(GetCarCountByTranmissionIsManuelCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByTranmissionIsManuel();
            return new GetCarCountByTranmissionIsManuelCountQueryResult
            {
                CarCountByTranmissionIsManuelCount = value,
            };
        }
    }
}
