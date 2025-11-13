using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.YakitTuruQueries;
using UdemyCarBook.Application.Features.Mediator.Results.YakitTuruResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.YakitTuruHandlers
{
    public class GetYakitTuruQueryHandler : IRequestHandler<GetYakitTuruQuery, List<GetYakitTuruQueryResult>>
    {
        private readonly IRepository<YakitTuru> _repository;

        public GetYakitTuruQueryHandler(IRepository<YakitTuru> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetYakitTuruQueryResult>> Handle(GetYakitTuruQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetYakitTuruQueryResult
            {
                YakitTuruID = x.YakitTuruID,
                Name= x.Name
            }).ToList();
        }
    }
}
