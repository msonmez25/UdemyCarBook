using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateCommentCommand>
    {

        private readonly IRepository<Comment> _repository;

        public UpdateTagCloudCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CommentID);
            values.Name = request.Name;
            values.Description = request.Description;
            values.CreatedDate = request.CreatedDate;
            values.Status = request.Status;
            values.BlogID = request.BlogID;
            values.Email = request.Email;
            await _repository.UpdateAsync(values);
        }
    }
}
