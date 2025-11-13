using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.VitesCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.VitesHandlers
{
    public class RemoveVitesCommandHandler : IRequestHandler<RemoveVitesCommand>
    {
        private readonly IRepository<Vites> _repository;

        public RemoveVitesCommandHandler(IRepository<Vites> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveVitesCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
