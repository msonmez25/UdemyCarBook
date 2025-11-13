using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetCarCountByTranmissionIsAuto();
        int GetCarCountByTranmissionIsManuel();
        int GetBrandCount();
        string GetBrandNameByMaxCar();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        string GetBlogTitleByMaxBlogComment();
        decimal GetAvgRentPriceForDaily();
        decimal GetAvgRentPriceForWeekly();
        decimal GetAvgRentPriceForMonthly();
        int GetCarCountByFuelGasolineOrDisel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceDailyMin();
        string GetCarBrandAndModelByRentPriceDailyMax();
    }
}
