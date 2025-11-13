using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int id = _context.Pricings.Where(x=>x.Name=="Günlük").Select(y=>y.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(k => k.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Aylık").Select(y => y.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(k => k.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Haftalık").Select(y => y.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(z => z.PricingID == id).Average(k => k.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            //select top(1) BlogID,COUNT(*) as 'yorumSayisi' from Comments Group By BlogID Order By yorumSayisi Desc

            var values = _context.Comments.GroupBy(x => x.BlogID).
                                             Select(y => new
                                             {
                                                 BlogID = y.Key,
                                                 Count = y.Count()
                                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();

            string blogTitle = _context.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefault();
            return blogTitle;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetBrandNameByMaxCar()
        {
            var  values = _context.Cars.GroupBy(x => x.BrandID).
                                             Select(y => new
                                             {
                                                BrandID = y.Key,
                                                Count = y.Count()
                                             }).OrderByDescending(z=>z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x=>x.PricingID == pricingId).Max(y=>y.Amount);
            int carId = _context.CarPricings.Where(x=>x.Amount ==amount).Select(y=>y.CarID).FirstOrDefault();
            string brandName = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandName;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingID == pricingId).Min(y => y.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandName = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandName;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            int id = _context.YakitTurus.Where(x => x.Name == "Elektrik").Select(y => y.YakitTuruID).FirstOrDefault();
            var value = _context.Cars.Where(z => z.YakitTuruID == id).Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDisel()
        {
            int id1 = _context.YakitTurus.Where(x => x.Name == "Benzin").Select(y => y.YakitTuruID).FirstOrDefault();
            var value1 = _context.Cars.Where(z => z.YakitTuruID == id1).Count();

            int id2 = _context.YakitTurus.Where(x => x.Name == "Dizel").Select(y => y.YakitTuruID).FirstOrDefault();
            var value2 = _context.Cars.Where(z => z.YakitTuruID == id2).Count();

            return value1 + value2;
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            int id = _context.Viteses.Where(x => x.Name == "Otomatik").Select(y => y.VitesID).FirstOrDefault();
            var value = _context.Cars.Where(z => z.VitesID == id).Count();
            return value;
        }

        public int GetCarCountByTranmissionIsManuel()
        {
            int id = _context.Viteses.Where(x => x.Name == "Manuel").Select(y => y.VitesID).FirstOrDefault();
            var value = _context.Cars.Where(z => z.VitesID == id).Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
