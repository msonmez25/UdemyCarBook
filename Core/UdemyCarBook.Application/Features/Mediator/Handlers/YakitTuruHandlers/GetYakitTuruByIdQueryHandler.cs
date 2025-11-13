using MediatR;
using System;
using System.Collections;
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
    public class GetYakitTuruByIdQueryHandler : IRequestHandler<GetYakitTuruByIdQuery, GetYakitTuruByIdQueryResult>
    {
        private readonly IRepository<YakitTuru> _repository;

        public GetYakitTuruByIdQueryHandler(IRepository<YakitTuru> repository)
        {
            _repository = repository;
        }

        public async Task<GetYakitTuruByIdQueryResult> Handle(GetYakitTuruByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetYakitTuruByIdQueryResult
            {
                YakitTuruID = values.YakitTuruID,
                Name = values.Name
            };
        }
    }
}
