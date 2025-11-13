using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.AppRoleCommands
{
    public class RemoveAppRoleCommand : IRequest
    {
        public RemoveAppRoleCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
