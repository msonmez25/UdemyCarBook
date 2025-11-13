using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class Vites
    {
        public int VitesID { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
