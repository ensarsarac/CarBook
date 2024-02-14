using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface StatisticInterfaces
    {
        int GetLocationCount();
        int GetAuthorCount();
        int GetBrandCount();
        decimal GetDayAvgPriceRentACar();
        decimal GetWeekAvgPriceRentACar();
        decimal GetMonthAvgPriceRentACar();
        int AutomaticTransmissionCar();
        string MaxBrandCar();
        string MaxCommentByBlog();
        int GetCarCountByKmSmallerThen1000();
        int GetCarCountByFuelBenzine();
        int GetCarCountByFuelDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceMax();
        string GetCarBrandAndModelByRentPriceMin();
    }
}
