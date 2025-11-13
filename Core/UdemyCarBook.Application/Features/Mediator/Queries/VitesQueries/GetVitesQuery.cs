using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.VitesResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.VitesQueries
{
    public class GetVitesQuery : IRequest<List<GetVitesQueryResult>>
    {
    }
}
