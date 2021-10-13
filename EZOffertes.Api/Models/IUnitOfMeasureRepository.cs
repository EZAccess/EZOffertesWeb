using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IUnitOfMeasureRepository
    {
        Task<IEnumerable<UnitOfMeasure>> GetUnitsOfMeasure();
        Task<UnitOfMeasure> GetUnitOfMeasure(int unitOfMeasureId);
        Task<UnitOfMeasure> AddUnitOfMeasure(UnitOfMeasure unitOfMeasure);
        Task<UnitOfMeasure> UpdateUnitOfMeasure(UnitOfMeasure unitOfMeasure);
        Task<UnitOfMeasure> DeleteUnitOfMeasure(int unitOfMeasureId);
    }
}
