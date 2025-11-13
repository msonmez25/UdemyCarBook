using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.AppRoleCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppRoleHandlers
{
    public class CreateAppRoleCommandHandler : IRequestHandler<CreateAppRoleCommand>
    {
        private readonly IRepository<AppRole> _repository;

        public CreateAppRoleCommandHandler(IRepository<AppRole> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppRoleCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppRole
            {
                AppRoleName = request.AppRoleName
            });
        }
    }
}
