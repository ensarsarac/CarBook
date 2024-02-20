using Application.ViewModels;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetAllCarPricingWithInclude();
        Task<List<CarPricing>> GetLast5CarPricingWithBrand();
        List<CarPricingViewModel> GetCarPricingWithAllTimePeriod();
    }
}
