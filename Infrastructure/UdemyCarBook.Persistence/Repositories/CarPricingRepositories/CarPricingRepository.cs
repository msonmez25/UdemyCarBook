using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarPricingInterface;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingByCarIdToDaily(int id)
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Where(x=>x.CarID == id).Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(k => k.PricingID == pricingId).ToList();
            return values;
        }

        public List<CarPricing> GetCarPricingByCarIdToPricingName(int id)
        {
            var values = _context.CarPricings.Where(x => x.CarID == id).Include(z=>z.Pricing).ToList();            
            return values;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            int id = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(k => k.PricingID == id).ToList();
            return values;
        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select * from(select Brands.Name+'  '+ Model as Marka,CoverImageUrl,Cars.CarScore,Cars.CarID,PricingID,Amount from CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarID Inner Join Brands on Cars.BrandID=Brands.BrandID)As SourceTable Pivot(Sum(Amount) For PricingID In ([1],[3],[4],[5])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            CarScore = reader["CarScore"].ToString(),
                            Model = reader["Marka"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            CarID = reader["CarID"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader["1"]),
                                Convert.ToDecimal(reader["3"]),
                                Convert.ToDecimal(reader["4"]),
                                Convert.ToDecimal(reader["5"])
                            }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
    }
}
