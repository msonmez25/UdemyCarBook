using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string IssuerSigningKey = "CarB0ok*01+CarB0ok*01+CarB0ok*01+CarB0ok*01+CarB0ok*01+";
        public const int Expire = 3;
    }
}
