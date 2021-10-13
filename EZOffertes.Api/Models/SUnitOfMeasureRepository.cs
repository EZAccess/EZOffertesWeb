using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SUnitOfMeasureRepository : IUnitOfMeasureRepository
    {
        private readonly AppDbContext appDbContext;

        public SUnitOfMeasureRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<UnitOfMeasure> AddUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            var result = await appDbContext.UnitsOfMeasure.AddAsync(unitOfMeasure);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UnitOfMeasure> DeleteUnitOfMeasure(int unitOfMeasureId)
        {
            var result = await appDbContext.UnitsOfMeasure.FirstOrDefaultAsync(e => e.UnitOfMeasureId == unitOfMeasureId);
            if (result != null)
            {
                appDbContext.UnitsOfMeasure.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<UnitOfMeasure> GetUnitOfMeasure(int unitOfMeasureId)
        {
            return await appDbContext.UnitsOfMeasure
                .FirstOrDefaultAsync(e => e.UnitOfMeasureId == unitOfMeasureId );
        }

        public async Task<IEnumerable<UnitOfMeasure>> GetUnitsOfMeasure()
        {
            return await appDbContext.UnitsOfMeasure.ToListAsync();
        }

        public async Task<UnitOfMeasure> UpdateUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            var result = await appDbContext.UnitsOfMeasure.FirstOrDefaultAsync(e => e.UnitOfMeasureId == unitOfMeasure.UnitOfMeasureId);
            if (result != null)
            {
                result.Unit = unitOfMeasure.Unit;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
