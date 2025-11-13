using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.RentACarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class CreateRentACarCommandHandler : IRequestHandler<CreateRentACarCommand>
    {
        private readonly IRepository<RentACar> _repository;

        public CreateRentACarCommandHandler(IRepository<RentACar> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRentACarCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new RentACar
            {
                CarID = request.CarID,
                LocationID = request.LocationID,
                Avaible = true,
            });
        }
    }
}
