using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureDetailCommands;
using UdemyCarBook.Application.Interfaces.CarFeatureDetailInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureDetailHandlers
{
    public class UpdateCarFeatureAvaibleChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvaibleChangeToTrueCommand>
    {
        private readonly ICarFeatureDetailRepository _repository;

        public UpdateCarFeatureAvaibleChangeToTrueCommandHandler(ICarFeatureDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureAvaibleChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeFeatureAvaibleToTrue(request.Id);            
        }
    }
}
