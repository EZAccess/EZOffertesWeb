using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SPersonTitleRepository : IPersonTitleRepository
    {
        private readonly AppDbContext appDbContext;

        public SPersonTitleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PersonTitle> AddPersonTitle(PersonTitle personTitle)
        {
            var result = await appDbContext.PersonTitles.AddAsync(personTitle);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PersonTitle> DeletePersonTitle(int personTitleId)
        {
            var result = await appDbContext.PersonTitles.FirstOrDefaultAsync(e => e.PersonTitleId == personTitleId);
            if (result != null)
            {
                appDbContext.PersonTitles.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<PersonTitle> GetPersonTitle(int personTitleId)
        {
            return await appDbContext.PersonTitles
                .FirstOrDefaultAsync(e => e.PersonTitleId == personTitleId);
        }

        public async Task<IEnumerable<PersonTitle>> GetPersonTitles()
        {
            return await appDbContext.PersonTitles.ToListAsync();
        }

        public async Task<PersonTitle> UpdatePersonTitle(PersonTitle personTitle)
        {
            var result = await appDbContext.PersonTitles.FirstOrDefaultAsync(e => e.PersonTitleId == personTitle.PersonTitleId);
            if (result != null)
            {
                result.Title = personTitle.Title;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
