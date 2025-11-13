using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.YakitTuruCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.YakitTuruHandlers
{
    public class UpdateYakitTuruCommandHandler : IRequestHandler<UpdateYakitTuruCommand>
    {
        private readonly IRepository<YakitTuru> _repository;

        public UpdateYakitTuruCommandHandler(IRepository<YakitTuru> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateYakitTuruCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.YakitTuruID);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
