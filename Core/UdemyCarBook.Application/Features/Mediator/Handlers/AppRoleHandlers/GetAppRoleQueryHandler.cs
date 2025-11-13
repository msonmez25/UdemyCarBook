using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AppRoleQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AppRoleResults;
using UdemyCarBook.Application.Features.Mediator.Results.VitesResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppRoleHandlers
{
    public class GetAppRoleQueryHandler : IRequestHandler<GetAppRoleQuery, List<GetAppRoleQueryResult>>
    {
        private readonly IRepository<AppRole> _repository;

        public GetAppRoleQueryHandler(IRepository<AppRole> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppRoleQueryResult>> Handle(GetAppRoleQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAppRoleQueryResult
            {
                AppRoleID = x.AppRoleID,
                AppRoleName = x.AppRoleName
            }).ToList();
        }
    }
}
