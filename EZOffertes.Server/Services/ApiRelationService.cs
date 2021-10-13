using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiRelationService : HttpService, IRelationService
    {
        public ApiRelationService(HttpClient httpClient) : base(httpClient) { }


        public async Task<Relation> CreateRelation(Relation newRelation, ErrorInfo err) =>
            (await HttpPost<Relation>($"api/relations", newRelation, err));

        public async Task<bool> DeleteRelation(int id, ErrorInfo err) =>
            (await HttpDelete($"api/relations/{id}", err));

        public async Task<Relation> GetRelation(int id, ErrorInfo err) =>
            (await HttpGet<Relation>($"api/relations/{id}", err));

        public async Task<IEnumerable<Relation>> GetRelations(ErrorInfo err) =>
            (await HttpGet<IEnumerable<Relation>>("api/relations", err));

        public async Task<IEnumerable<Relation>> Search(string name, ErrorInfo err) =>
            (await HttpGet<Relation[]>($"api/relations/search/{name}", err));

        public async Task<Relation> UpdateRelation(Relation updatedRelation, ErrorInfo err) =>
            (await HttpPut<Relation>("api/relations", updatedRelation, err));

    }
}
