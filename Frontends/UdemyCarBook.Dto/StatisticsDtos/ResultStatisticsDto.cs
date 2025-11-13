using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }
        public int BrandCount { get; set; }
        public int CarCountByTranmissionIsAutoCount { get; set; }
        public int CarCountByTranmissionIsManuelCount { get; set; }
        public int CarCountByFuelElectric { get; set; }
        public int CarCountByFuelGasolineOrDisel { get; set; }
        public int LocationCount { get; set; }
        public string BrandNameByMaxCar { get; set; }
        public decimal AvgRentPriceForDaily { get; set; }
        public decimal AvgRentPriceForMonthly { get; set; }
        public decimal AvgRentPriceForWeekly { get; set; }
        public string CarBrandAndModelByRentPriceDailyMin { get; set; }
        public string CarBrandAndModelByRentPriceDailyMax { get; set; }
        public int BlogCount { get; set; }
        public int AuthorCount { get; set; }
        public string BlogTitleByMaxBlogComment { get; set; }
    }
}
