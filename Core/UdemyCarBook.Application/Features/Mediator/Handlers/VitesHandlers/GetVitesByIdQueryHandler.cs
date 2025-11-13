using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.VitesQueries;
using UdemyCarBook.Application.Features.Mediator.Results.VitesResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.VitesHandlers
{
    public class GetVitesByIdQueryHandler : IRequestHandler<GetVitesByIdQuery, GetVitesByIdQueryResult>
    {
        private readonly IRepository<Vites> _repository;

        public GetVitesByIdQueryHandler(IRepository<Vites> repository)
        {
            _repository = repository;
        }

        public async Task<GetVitesByIdQueryResult> Handle(GetVitesByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetVitesByIdQueryResult
            {
                VitesID = values.VitesID,
                Name = values.Name
            };
        }
    }
}
