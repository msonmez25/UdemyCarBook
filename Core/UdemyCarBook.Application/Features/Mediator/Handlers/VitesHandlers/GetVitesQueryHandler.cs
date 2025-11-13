using MediatR;
using System;
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
    public class GetVitesQueryHandler : IRequestHandler<GetVitesQuery, List<GetVitesQueryResult>>
    {
        private readonly IRepository<Vites> _repository;

        public GetVitesQueryHandler(IRepository<Vites> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetVitesQueryResult>> Handle(GetVitesQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetVitesQueryResult
            {
                VitesID = x.VitesID,
                Name= x.Name
            }).ToList();
        }
    }
}
