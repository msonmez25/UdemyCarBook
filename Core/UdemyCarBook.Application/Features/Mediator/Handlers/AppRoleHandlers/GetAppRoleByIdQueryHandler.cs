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
    public class GetAppRoleByIdQueryHandler : IRequestHandler<GetAppRoleByIdQuery, GetAppRoleByIdQueryResult>
    {
        private readonly IRepository<AppRole> _repository;

        public GetAppRoleByIdQueryHandler(IRepository<AppRole> repository)
        {
            _repository = repository;
        }

        public async Task<GetAppRoleByIdQueryResult> Handle(GetAppRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetAppRoleByIdQueryResult
            {
                AppRoleID = values.AppRoleID,
                AppRoleName = values.AppRoleName
            };
        }
    }
}
