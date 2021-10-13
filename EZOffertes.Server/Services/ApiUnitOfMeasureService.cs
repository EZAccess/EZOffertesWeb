using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiUnitOfMeasureService : HttpService, IUnitOfMeasureService
    {
        public ApiUnitOfMeasureService(HttpClient httpClient) : base(httpClient) { }


        public async Task<UnitOfMeasure> CreateUnitOfMeasure(UnitOfMeasure newUnitOfMeasure, ErrorInfo err) =>
            (await HttpPost<UnitOfMeasure>($"api/unitsofmeasure", newUnitOfMeasure, err));

        public async Task<bool> DeleteUnitOfMeasure(int id, ErrorInfo err) =>
            (await HttpDelete($"api/unitsofmeasure/{id}", err));

        public async Task<UnitOfMeasure> GetUnitOfMeasure(int id, ErrorInfo err) =>
            (await HttpGet<UnitOfMeasure>($"api/unitsofmeasure/{id}", err));

        public async Task<IEnumerable<UnitOfMeasure>> GetUnitsOfMeasure(ErrorInfo err) =>
            (await HttpGet<IEnumerable<UnitOfMeasure>>("api/unitsofmeasure", err));

        public async Task<UnitOfMeasure> UpdateUnitOfMeasure(UnitOfMeasure updatedUnitOfMeasure, ErrorInfo err) =>
            (await HttpPut<UnitOfMeasure>("api/unitsofmeasure", updatedUnitOfMeasure, err));

    }
}
