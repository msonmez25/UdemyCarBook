using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class CreateCarPricingCommand : IRequest
    {       
        public int PricingID { get; set; }
        public int CarID { get; set; }
        public decimal Amount { get; set; }
    }
}
