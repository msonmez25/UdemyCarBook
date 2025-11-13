using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarDescriptionCommands
{
	public class UpdateCarDescriptionCommand : IRequest
	{
		public int CarDescriptionID { get; set; }
		public int CarID { get; set; }
		public string Details { get; set; }
	}
}
