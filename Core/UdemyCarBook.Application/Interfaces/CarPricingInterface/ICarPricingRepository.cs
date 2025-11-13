using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarPricingInterface
{
    public interface ICarPricingRepository
    {
        List<CarPricing> GetCarPricingWithCars();
        List<CarPricingViewModel> GetCarPricingWithTimePeriod();

        List<CarPricing> GetCarPricingByCarIdToPricingName(int id);
        List<CarPricing> GetCarPricingByCarIdToDaily(int id);

    }
}
