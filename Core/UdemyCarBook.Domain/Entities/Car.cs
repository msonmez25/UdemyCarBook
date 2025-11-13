using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class Car
    {
        public int CarID { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }


        public int VitesID { get; set; }
        public Vites Vites { get; set; }


        public int YakitTuruID { get; set; }
        public YakitTuru YakitTuru { get; set; }

        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public int Year { get; set; }
       
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        
        public string BigImageUrl { get; set; }
        public string CarScore { get; set; }

        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<RentACarProcess> RentACarProcesses { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
