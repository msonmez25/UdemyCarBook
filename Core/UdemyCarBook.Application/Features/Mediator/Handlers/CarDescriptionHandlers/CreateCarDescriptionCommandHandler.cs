using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CarDescriptionCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class CreateCarDescriptionCommandHandler : IRequestHandler<CreateCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;

        public CreateCarDescriptionCommandHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarDescription
			{
                CarID = request.CarID,
                Details = request.Details
            });
        }
    }
}
