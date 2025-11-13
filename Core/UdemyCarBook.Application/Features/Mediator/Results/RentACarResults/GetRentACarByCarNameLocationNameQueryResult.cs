using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.RentACarResults
{
    public class GetRentACarByCarNameLocationNameQueryResult
    {
        public int RentACarID { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int CarID { get; set; }
        public string CarName { get; set; }
        public bool Avaible { get; set; }
    }
}
