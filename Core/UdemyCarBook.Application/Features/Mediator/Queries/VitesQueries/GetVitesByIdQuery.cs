using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.VitesResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.VitesQueries
{
    public class GetVitesByIdQuery : IRequest<GetVitesByIdQueryResult>
    {
        public GetVitesByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
