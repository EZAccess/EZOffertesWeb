using Microsoft.Extensions.Configuration;
using EZOffertes.Models;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZOffertes.Server.Services;
using EZOffertes.Server.Shared;

namespace EZOffertes.Server.Pages
{
    public class OrdersPerCustomerBase : ComponentBase
    {
        [Parameter] public string Id { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }
        [Inject] public IOrderService OrderService { get; set; }

        //        public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel", "Search", "Print", "ExcelExport", "PdfExport", "CsvExport" };
        public string[] ToolbarItems = new string[] {"Print", "ExcelExport" };
        protected SfGrid<Order> DefaultGrid;
        //public string ErrorMessage { get; set; }
        //protected ErrorHandler Err;
        protected ErrorInfo Err { get; set; } = new ErrorInfo();
        public IEnumerable<Order> Orders { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Err = new();
            Orders = await OrderService.GetOrdersOfCustomer(int.Parse(Id), Err);
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

        protected void HandleRecordClick(RecordClickEventArgs<Order> args)
        {
            //NavigationManager.NavigateTo($"/ordermaintain/{args.RowData.OrderId}", true);
        }

        protected void HandleAddOrder()
        {
            NavigationManager.NavigateTo($"/ordermaintain/0/{Id}", true);
        }

        protected void HandleExcelExport()
        {
            DefaultGrid.ExcelExport();
        }

        protected void HandleEditOrder()
        {
            
            NavigationManager.NavigateTo($"/ordermaintain/{DefaultGrid.SelectedRecords.FirstOrDefault().OrderId}/{Id}", true);
        }

    }
}
