using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.AppRoleCommands
{
    public class CreateAppRoleCommand : IRequest
    {
        public string AppRoleName { get; set; }
    }
}
