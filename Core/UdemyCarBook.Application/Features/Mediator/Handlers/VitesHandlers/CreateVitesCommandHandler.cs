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
    public class CreateVitesCommandHandler : IRequestHandler<CreateVitesCommand>
    {
        private readonly IRepository<Vites> _repository;

        public CreateVitesCommandHandler(IRepository<Vites> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateVitesCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Vites
            {
               Name = request.Name
            });
        }
    }
}
