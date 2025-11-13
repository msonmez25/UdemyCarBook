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
    public class UpdateVitesCommandHandler : IRequestHandler<UpdateVitesCommand>
    {
        private readonly IRepository<Vites> _repository;

        public UpdateVitesCommandHandler(IRepository<Vites> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateVitesCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.VitesID);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
