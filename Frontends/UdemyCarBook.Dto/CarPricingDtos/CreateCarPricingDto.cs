using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CarPricingDtos
{
    public class CreateCarPricingDto
    {
        public int PricingID { get; set; }
        public int CarID { get; set; }
        public decimal Amount { get; set; }
    }
}
