using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> Search(string name, ErrorInfo err);
        Task<IEnumerable<Employee>> GetEmployees(ErrorInfo err);
        Task<Employee> GetEmployee(int id, ErrorInfo err);
        Task<Employee> UpdateEmployee(Employee updatedEmployee, ErrorInfo err);
        Task<Employee> CreateEmployee(Employee newEmployee, ErrorInfo err);
        Task<bool> DeleteEmployee(int id, ErrorInfo err);

    }
}
