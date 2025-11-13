using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

		public List<Car> GetCarDetailListByCarID(int id)
		{
			var value = _context.Cars.Where(x=>x.CarID == id).Include(X => X.Brand).Include(y => y.YakitTuru).Include(z => z.Vites).ToList();
            return value;
		}

		public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(X => X.Brand).Include(y=>y.YakitTuru).Include(z=>z.Vites).ToList();
            return values;
        }

        public List<Car> GetCarsWithPricings()
        {
            var values = _context.Cars.Include(X => X.Brand).Include(y=>y.CarPricings).ThenInclude(z=>z.Pricing).ToList();
            return values;
        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(X => X.Brand).Include(y => y.YakitTuru).Include(z => z.Vites).OrderByDescending(x=>x.CarID).Take(5).ToList();
            return values;
        }

        public Car GetCarInfoByCarId(int id)
        {
            var value = _context.Cars.Where(x => x.CarID == id).Include(X => X.Brand).Include(y => y.YakitTuru).Include(z => z.Vites).FirstOrDefault();
            return value;
        }
    }
}
