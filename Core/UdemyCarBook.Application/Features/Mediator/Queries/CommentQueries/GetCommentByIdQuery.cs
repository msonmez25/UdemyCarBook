using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CommentResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentByIdQuery : IRequest<GetCommentByIdQueryResult>
    {
        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
