using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.RegisterDtos
{
    public class CreateRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
