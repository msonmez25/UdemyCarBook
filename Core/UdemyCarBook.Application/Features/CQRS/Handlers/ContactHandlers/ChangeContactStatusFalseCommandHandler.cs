using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces.ContactInterfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class ChangeContactStatusFalseCommandHandler
    {
        private readonly IContactRepository _contactRepository;

        public ChangeContactStatusFalseCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(ChangeContactStatusFalseCommand command)
        {
            _contactRepository.ChangeStatusFalse(command.Id);
        }
    }
}
