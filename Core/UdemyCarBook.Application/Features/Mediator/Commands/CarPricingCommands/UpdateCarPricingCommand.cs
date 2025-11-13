using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class UpdateCarPricingCommand : IRequest
    {
        public int CarPricingID { get; set; }
        public int PricingID { get; set; }
        public int CarID { get; set; }
        public decimal Amount { get; set; }
    }
}
