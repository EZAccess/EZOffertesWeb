using EZOffertes.Models;
using EZOffertes.Server.Services;
using EZOffertes.Server.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Pages
{
    public class CustomersBase : ComponentBase
    {
        [Inject] public IConfiguration Configuration { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IRelationService RelationService { get; set; }

        protected SfGrid<Relation> DefaultGrid;
//        public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel", "Search", "Print", "ExcelExport", "PdfExport", "CsvExport" };
        public string[] ToolbarItems = new string[] { "Print", "ExcelExport" };
        public IEnumerable<Relation> Relations { get; set; }
        public bool ShowSpinner { get; set; }
        protected ErrorInfo Err { get; set; } = new ErrorInfo();

        protected async override Task OnInitializedAsync()
        {
            ShowSpinner = true;
            Relations = await RelationService.GetRelations(Err);
            ShowSpinner = false;
        }

        protected async Task HandleToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
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

        protected void HandleRowSelected(RowSelectEventArgs<Relation> args)
        {
            NavigationManager.NavigateTo($"/customers/orderspercustomer/{args.Data.RelationId}", true);
        }
    }
}
