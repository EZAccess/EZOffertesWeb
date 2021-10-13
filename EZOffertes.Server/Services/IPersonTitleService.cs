using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IPersonTitleService
    {
        Task<IEnumerable<PersonTitle>> GetPersonTitles(ErrorInfo err);
        Task<PersonTitle> GetPersonTitle(int id, ErrorInfo err);
        Task<PersonTitle> UpdatePersonTitle(PersonTitle updatedPersonTitle, ErrorInfo err);
        Task<PersonTitle> CreatePersonTitle(PersonTitle newPersonTitle, ErrorInfo err);
        Task<bool> DeletePersonTitle(int id, ErrorInfo err);
    }
}
