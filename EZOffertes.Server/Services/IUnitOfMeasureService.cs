using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IUnitOfMeasureService
    {
        Task<IEnumerable<UnitOfMeasure>> GetUnitsOfMeasure(ErrorInfo err);
        Task<UnitOfMeasure> GetUnitOfMeasure(int id, ErrorInfo err);
        Task<UnitOfMeasure> UpdateUnitOfMeasure(UnitOfMeasure updatedUnitOfMeasure, ErrorInfo err);
        Task<UnitOfMeasure> CreateUnitOfMeasure(UnitOfMeasure newUnitOfMeasure, ErrorInfo err);
        Task<bool> DeleteUnitOfMeasure(int id, ErrorInfo err);

    }
}
