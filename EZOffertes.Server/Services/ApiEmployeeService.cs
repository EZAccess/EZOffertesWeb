using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiEmployeeService : HttpService, IEmployeeService
    {
        public ApiEmployeeService(HttpClient httpClient) : base(httpClient) { }


        public async Task<Employee> CreateEmployee(Employee newEmployee, ErrorInfo err) =>
            (await HttpPost<Employee>($"api/employees", newEmployee, err));

        public async Task<bool> DeleteEmployee(int id, ErrorInfo err) =>
            (await HttpDelete($"api/employees/{id}", err));

        public async Task<Employee> GetEmployee(int id, ErrorInfo err) =>
            (await HttpGet<Employee>($"api/employees/{id}", err));

        public async Task<IEnumerable<Employee>> GetEmployees(ErrorInfo err) =>
            (await HttpGet<IEnumerable<Employee>>("api/employees", err));

        public async Task<IEnumerable<Employee>> Search(string name, ErrorInfo err) =>
            (await HttpGet<Employee[]>($"api/employees/search/{name}", err));

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee, ErrorInfo err) =>
            (await HttpPut<Employee>("api/employees", updatedEmployee, err));

    }
}
