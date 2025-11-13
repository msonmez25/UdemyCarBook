using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CommentQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Features.Mediator.Results.CommentResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Application.Interfaces.CommenttInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentByBlogIdQueryHandler : IRequestHandler<GetCommetByBlogIdQuery, List<GetCommentByBLogIdQueryResult>>
    {

        private readonly ICommenttRepository _repository;

        public GetCommentByBlogIdQueryHandler(ICommenttRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentByBLogIdQueryResult>> Handle(GetCommetByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCommettByBlogId(request.Id);
            return values.Select(x => new GetCommentByBLogIdQueryResult
            {
                BlogID = x.BlogID,
                CreatedDate = x.CreatedDate,
                CommentID = x.CommentID,
                Description = x.Description,
                Name = x.Name,
                Status = x.Status,
                BlogName = x.Blog.Title,
                Email = x.Email
            }).ToList();
        }
    }
}
