using EZOffertes.Models;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Components
{
    public class DataGridSf1Base : ComponentBase
    {
        [Parameter]
        public DataGridSfInfo DataGridSfInfo { get; set; }

        public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel", "Search", "Print", "ExcelExport", "PdfExport", "CsvExport" };
        protected string ActionBegin { get; set; }
        protected string ActionComplete { get; set; }
        protected SfGrid<Employee> DefaultGrid;

        protected async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id == "Grid_excelexport")
            {
                await this.DefaultGrid.ExcelExport();
            }
        }
    }
}
