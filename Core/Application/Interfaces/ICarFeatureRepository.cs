using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetAllWithInclude(int id);
        Task CarFeatureAvailablaChangeTrue(int id);
        Task CarFeatureAvailablaChangeFalse(int id);
    }
}
