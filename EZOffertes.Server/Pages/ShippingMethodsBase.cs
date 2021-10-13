using Microsoft.Extensions.Configuration;
using EZOffertes.Models;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZOffertes.Server.Services;
using EZOffertes.Server.Shared;

namespace EZOffertes.Server.Pages
{
    public class ShippingMethodsBase : ComponentBase
    {
        [Inject] public IConfiguration Configuration { get; set; }
        [Inject] public IShippingMethodService ShippingMethodService { get; set; }
        
        //        public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel", "Search", "Print", "ExcelExport", "PdfExport", "CsvExport" };
        public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel", "Print", "ExcelExport" };
        protected SfGrid<ShippingMethod> DefaultGrid;
        public List<ShippingMethod> ShippingMethods { get; set; }
        protected ErrorInfo Err { get; set; } = new ErrorInfo();

        protected async override Task OnInitializedAsync() =>
            ShippingMethods = (await ShippingMethodService.GetShippingMethods(Err)).ToList();

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
