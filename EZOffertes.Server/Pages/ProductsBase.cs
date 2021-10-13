﻿using Microsoft.Extensions.Configuration;
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
    public class ProductsBase : ComponentBase
    {
        [Inject] public IConfiguration Configuration { get; set; }
        [Inject] public IProductService ProductService { get; set; }

        //        public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel", "Search", "Print", "ExcelExport", "PdfExport", "CsvExport" };
        public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel", "Print", "ExcelExport" };
        protected SfGrid<Product> DefaultGrid;
        public List<Product> Products { get; set; }
        protected ErrorInfo Err { get; set; } = new ErrorInfo();

        protected async override Task OnInitializedAsync() =>
            Products = (await ProductService.GetProducts(Err)).ToList();

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
