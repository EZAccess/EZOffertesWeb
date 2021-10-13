using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IPersonTitleRepository
    {
        Task<IEnumerable<PersonTitle>> GetPersonTitles();
        Task<PersonTitle> GetPersonTitle(int personTitleId);
        Task<PersonTitle> AddPersonTitle(PersonTitle personTitle);
        Task<PersonTitle> UpdatePersonTitle(PersonTitle personTitle);
        Task<PersonTitle> DeletePersonTitle(int personTitleId);
    }
}
