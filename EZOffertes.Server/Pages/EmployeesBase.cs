using Microsoft.Extensions.Configuration;
using EZOffertes.Models;
using EZOffertes.Server.Services;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.FileManager;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZOffertes.Server.Shared;

namespace EZOffertes.Server.Pages
{
    public class EmployeesBase : ComponentBase
    {
        [Inject] public IConfiguration Configuration { get; set; }
        [Inject] public IEmployeeService EmployeeService { get; set; }

        public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel", "Search", "Print", "ExcelExport", "PdfExport", "CsvExport" };
        protected SfGrid<Employee> DefaultGrid;
        public List<Employee> Employees { get; set; }
        protected ErrorInfo Err { get; set; } = new ErrorInfo();

        protected async override Task OnInitializedAsync() =>
            Employees = (await EmployeeService.GetEmployees(Err)).ToList();

        protected async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id == "Grid_excelexport")
            {
                await this.DefaultGrid.ExcelExport();
            }
            if (args.Item.Id == "Grid_pdfexport")
            {
                await this.DefaultGrid.PdfExport();
            }
        }
    }
}
