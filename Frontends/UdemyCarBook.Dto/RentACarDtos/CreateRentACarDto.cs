using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.RentACarDtos
{
    public class CreateRentACarDto
    {
        public int LocationID { get; set; }
        public int CarID { get; set; }
        public bool Avaible { get; set; }
    }
}
