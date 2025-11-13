using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AppRoleResults;
using UdemyCarBook.Application.Features.Mediator.Results.AppUserResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserByIdQueryHandler : IRequestHandler<GetAppUserByIdQuery, GetAppUserByIdQueryResult>
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserByIdQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetAppUserIdByRoleName(request.Id);
            return new GetAppUserByIdQueryResult
            {
                AppUserID =values.AppUserID,
                Age = values.Age,
                AppRoleID = values.AppRoleID,
                AppRoleName = values.AppRole.AppRoleName,
                Mail = values.Mail,
                Name = values.Name,
                Password = values.Password,
                Phone = values.Phone,
                Surname = values.Surname,
                Username = values.Username

            };
        }
    }
}
