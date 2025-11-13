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
    public class UpdateAppRoleCommandHandler : IRequestHandler<UpdateAppRoleCommand>
    {
        private readonly IRepository<AppRole> _repository;

        public async Task Handle(UpdateAppRoleCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AppRoleID);
            values.AppRoleName = request.AppRoleName;
            await _repository.UpdateAsync(values);
        }
    }
}
