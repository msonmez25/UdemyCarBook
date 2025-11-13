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
    public class CreateYakitTuruCommandHandler : IRequestHandler<CreateYakitTuruCommand>
    {
        private readonly IRepository<YakitTuru> _repository;

        public CreateYakitTuruCommandHandler(IRepository<YakitTuru> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateYakitTuruCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new YakitTuru
            {
               Name = request.Name
            });
        }
    }
}
