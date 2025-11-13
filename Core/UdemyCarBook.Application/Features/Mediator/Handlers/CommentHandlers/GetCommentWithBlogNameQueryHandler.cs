using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CommentQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CommentResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CommenttInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentWithBlogNameQueryHandler : IRequestHandler<GetCommentWithBlogNameQuery, List<GetCommentWithBlogNameQueryResult>>
    {
        private readonly ICommenttRepository _repository;

        public GetCommentWithBlogNameQueryHandler(ICommenttRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentWithBlogNameQueryResult>> Handle(GetCommentWithBlogNameQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetCommentsByBlogCategoryName();
            return values.Select(x => new GetCommentWithBlogNameQueryResult
            {
                CommentID = x.CommentID,
                Name = x.Name,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                Status = x.Status,
                BlogID = x.BlogID,
                BlogName = x.Blog.Title,
                BlogCategoryName = x.Blog.Category.Name,
                Email = x.Email
            }).ToList();
        }
    }
}
