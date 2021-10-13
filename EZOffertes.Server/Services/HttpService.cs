using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using EZOffertes.Server.Shared;

namespace EZOffertes.Server.Services
{
    public class HttpService
    {
        protected readonly HttpClient httpClient;

        public HttpService(HttpClient httpClient) =>
            this.httpClient = httpClient;
        

        protected async Task<T> HttpGet<T>(String requestUri, ErrorInfo err)
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                err.Code = null;
                err.Message = null;
                return result;
            }
            else
            {
                err.Code = response.StatusCode.ToString();
                err.Message = $"An error occured while requesting data from the server: {response.StatusCode}";
                return default;
            }
        }

        protected async Task<T> HttpPost<T>(String requestUri, T newT, ErrorInfo err)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync<T>(requestUri, newT);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                err.Code = null;
                return result;
            }
            else
            {
                err.Code = response.StatusCode.ToString();
                err.Message = $"An error occured while writing data to the server: {response.StatusCode}";
                return default;
            }
        }

        protected async Task<T> HttpPut<T>(String requestUri, T updatedT, ErrorInfo err)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync<T>(requestUri, updatedT);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                err.Code = null;
                return result;
            }
            else
            {
                err.Code = response.StatusCode.ToString();
                err.Message = $"An error occured while writing data to the server: {response.StatusCode}";
                return default;
            }
        }

        protected async Task<bool> HttpDelete(String requestUri, ErrorInfo err)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                err.Code = null;
                return true;
            }
            else
            {
                err.Code = response.StatusCode.ToString();
                err.Message = $"An error occured while deleting data at the server: {response.StatusCode}";
                return false;
            }
        }

    }//class
}//namespace
