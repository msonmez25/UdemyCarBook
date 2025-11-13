using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarFeatureDetailInterfaces
{
    public interface ICarFeatureDetailRepository
    {
        public List<CarFeature> GetCarFeatureDetailByCarId(int carID);
        void ChangeFeatureAvaibleToTrue(int id);
        void ChangeFeatureAvaibleToFalse(int id);
        void CreateCarFeatureByCar(CarFeature carFeature);
    }
}
