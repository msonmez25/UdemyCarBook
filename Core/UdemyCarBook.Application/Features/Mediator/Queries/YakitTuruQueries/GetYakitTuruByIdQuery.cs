using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.YakitTuruResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.YakitTuruQueries
{
    public class GetYakitTuruByIdQuery : IRequest<GetYakitTuruByIdQueryResult>
    {
        public GetYakitTuruByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
