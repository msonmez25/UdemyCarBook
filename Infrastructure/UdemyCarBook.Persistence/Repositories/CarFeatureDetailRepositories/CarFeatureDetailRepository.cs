using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarFeatureDetailInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarFeatureDetailRepositories
{
    public class CarFeatureDetailRepository : ICarFeatureDetailRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureDetailRepository(CarBookContext context)
        {
            _context = context;
        }

        public void ChangeFeatureAvaibleToFalse(int id)
        {
            var values = _context.CarFeatures.Where(x=>x.CarFeatureID == id).FirstOrDefault();
            values.Available = false;
            _context.SaveChanges();
        }

        public void ChangeFeatureAvaibleToTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }

        public void CreateCarFeatureByCar(CarFeature carFeature)
        {
            _context.CarFeatures.Add(carFeature);
            _context.SaveChanges();
        }

        public List<CarFeature> GetCarFeatureDetailByCarId(int carID)
        {
            var values = _context.CarFeatures.Include(X => X.Feature).Where(x => x.CarID == carID).ToList();
            return values;
        }
    }
}
