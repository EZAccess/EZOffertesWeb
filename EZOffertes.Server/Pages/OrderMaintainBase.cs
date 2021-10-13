using Microsoft.Extensions.Configuration;
using EZOffertes.Models;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZOffertes.Server.Services;
using Syncfusion.Blazor.Navigations;
using EZOffertes.Server.Shared;

namespace EZOffertes.Server.Pages
{
    public class OrderMaintainBase : ComponentBase
    {
        [Parameter] public string OrderId { get; set; }
        [Parameter] public string CustomerId { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }
        [Inject] public IOrderDetailService OrderDetailService { get; set; }

        public List<object> ToolbarItems = new List<object>() {
            new ItemModel() { Text = "", TooltipText = "Add", PrefixIcon = "e-add", Id = "Grid_add" },
            new ItemModel() { Text = "", TooltipText = "Edit", PrefixIcon = "e-edit", Id = "Grid_edit" },
            new ItemModel() { Text = "", TooltipText = "Delete", PrefixIcon = "e-delete", Id = "Grid_delete" },
            new ItemModel() { Text = "", TooltipText = "Update", PrefixIcon = "e-update", Id = "Grid_update" },
            new ItemModel() { Text = "", TooltipText = "Cancel", PrefixIcon = "e-cancel", Id = "Grid_cancel" },
            new ItemModel() { Text = "", TooltipText = "Search" },
            new ItemModel() { Text = "", TooltipText = "Print", PrefixIcon = "e-print", Id = "Grid_print" },
            new ItemModel() { Text = "", TooltipText = "ExcelExport", PrefixIcon = "e-excelexport", Id = "Grid_excelexport" },
            new ItemModel() { Text = "", TooltipText = "PdfExport", PrefixIcon = "e-pdfexport", Id = "Grid_pdfexport" },
            new ItemModel() { Text = "", TooltipText = "CsvExport", PrefixIcon = "e-csvexport", Id = "Grid_csvexport" }
        };
        //public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel", "Search", "Print", "ExcelExport", "PdfExport", "CsvExport" };
        //public string[] ToolbarItems = new string[] { "Print", "ExcelExport" };
        protected SfGrid<OrderDetail> DefaultGrid;
        public List<OrderDetail> OrderDetails { get; set; }
        protected ErrorInfo Err { get; set; } = new ErrorInfo();

        protected async override Task OnInitializedAsync()
        {
            OrderDetails = (await OrderDetailService.GetOrderDetails(int.Parse(OrderId), Err)).ToList();
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

    }
}
