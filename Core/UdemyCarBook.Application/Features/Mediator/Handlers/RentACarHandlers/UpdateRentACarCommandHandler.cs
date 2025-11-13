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
    public class UpdateRentACarCommandHandler : IRequestHandler<UpdateRentACarCommand>
    {

        private readonly IRepository<RentACar> _repository;

        public UpdateRentACarCommandHandler(IRepository<RentACar> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRentACarCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.RentACarID);
            values.CarID = request.CarID;
            values.LocationID = request.LocationID;
            values.Avaible = true;
            await _repository.UpdateAsync(values);
        }
    }
}
