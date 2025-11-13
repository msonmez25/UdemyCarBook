using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AppRoleResults;
using UdemyCarBook.Application.Features.Mediator.Results.AppUserResults;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery,List<GetAppUserQueryResult>>
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetAppUsersByRoleName();
            return values.Select(x => new GetAppUserQueryResult
            {
                AppUserID = x.AppUserID,
                Age = x.Age,
                AppRoleID = x.AppRoleID,
                AppRoleName = x.AppRole.AppRoleName,
                Mail = x.Mail,
                Name = x.Name,
                Phone = x.Phone,
                Surname = x.Surname,
                Username = x.Username
            }).ToList();
        }
    }
}
