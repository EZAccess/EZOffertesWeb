using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiPersonTitleService : HttpService, IPersonTitleService
    {
        public ApiPersonTitleService(HttpClient httpClient) : base(httpClient) { }


        public async Task<PersonTitle> CreatePersonTitle(PersonTitle newPersonTitle, ErrorInfo err) =>
            (await HttpPost<PersonTitle>($"api/persontitles", newPersonTitle, err));

        public async Task<bool> DeletePersonTitle(int id, ErrorInfo err) =>
            (await HttpDelete($"api/persontitles/{id}", err));

        public async Task<PersonTitle> GetPersonTitle(int id, ErrorInfo err) =>
            (await HttpGet<PersonTitle>($"api/persontitles/{id}", err));

        public async Task<IEnumerable<PersonTitle>> GetPersonTitles(ErrorInfo err) =>
            (await HttpGet<IEnumerable<PersonTitle>>("api/persontitles", err));

        public async Task<PersonTitle> UpdatePersonTitle(PersonTitle updatedPersonTitle, ErrorInfo err) =>
            (await HttpPut<PersonTitle>("api/persontitles", updatedPersonTitle, err));

    }
}
