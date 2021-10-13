using Microsoft.Extensions.Configuration;
using EZOffertes.Models;
using EZOffertes.Server.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZOffertes.Server.Shared;

namespace EZOffertes.Server.Pages
{
    public class EmployeeFormBase : ComponentBase
    {
        [Parameter] public string Id { get; set; }

        [Inject] public IEmployeeService EmployeeService { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected ErrorInfo Err { get; set; } = new ErrorInfo();
        public Employee Employee { get; set; } = new Employee();

        protected async override Task OnInitializedAsync() =>
            Employee = await EmployeeService.GetEmployee(int.Parse(Id), Err);

        protected async Task HandleValidSubmit()
        {
            Employee result = null;
            if (Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee, Err);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee, Err);
            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
