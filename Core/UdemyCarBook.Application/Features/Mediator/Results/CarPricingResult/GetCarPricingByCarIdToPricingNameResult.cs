using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarPricingResult
{
    public class GetCarPricingByCarIdToPricingNameResult
    {
        public int CarPricingID { get; set; }
        public int PricingID { get; set; }
        public string PricingName { get; set; }
        public int CarID { get; set; }
        public decimal Amount { get; set; }
    }
}
