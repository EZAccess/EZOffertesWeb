using EZOffertes.Models;
using EZOffertes.Server.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Components
{
    public class EmployeeSelectBase : ComponentBase
    {
        [Inject] public IEmployeeService EmployeeService { get; set; }

        protected IEnumerable<Employee> Employees { get; set; }
        protected EZOffertes.Server.Shared.ErrorInfo Err { get; set; } = new EZOffertes.Server.Shared.ErrorInfo();

        protected async override Task OnInitializedAsync()
        {
            Employees = await EmployeeService.GetEmployees(Err);
        }
    }
}
