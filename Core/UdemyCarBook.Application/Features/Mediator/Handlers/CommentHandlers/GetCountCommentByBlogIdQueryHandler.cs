using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CommentQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CommentResults;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CommenttInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCountCommentByBlogIdQueryHandler : IRequestHandler<GetCountCommentByBlogIdQuery, GetCountCommentByBlogIdQueryResult>
    {

        private readonly ICommenttRepository _repository;

        public GetCountCommentByBlogIdQueryHandler(ICommenttRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCountCommentByBlogIdQueryResult> Handle(GetCountCommentByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCountCommentByBlog(request.Id);
            return new GetCountCommentByBlogIdQueryResult
            {
                CountCommentByBlogId = value,
            };
        }
    }
}
