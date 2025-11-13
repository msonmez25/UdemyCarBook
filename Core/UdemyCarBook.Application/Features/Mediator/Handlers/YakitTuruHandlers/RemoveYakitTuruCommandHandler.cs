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
    public class RemoveYakitTuruCommandHandler : IRequestHandler<RemoveYakitTuruCommand>
    {
        private readonly IRepository<YakitTuru> _repository;

        public RemoveYakitTuruCommandHandler(IRepository<YakitTuru> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveYakitTuruCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
