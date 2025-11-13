using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.AppRoleResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.AppRoleQueries
{
    public class GetAppRoleByIdQuery : IRequest<GetAppRoleByIdQueryResult>
    {
        public GetAppRoleByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
