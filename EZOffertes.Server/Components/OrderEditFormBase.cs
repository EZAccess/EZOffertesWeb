using EZOffertes.Models;
using EZOffertes.Server.Services;
using EZOffertes.Server.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Components
{
    public class OrderEditFormBase : ComponentBase
    {

        [Parameter] public int OrderId { get; set; }
        [Parameter] public int CustomerId { get; set; }

        [Inject] public IOrderService OrderService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected ErrorInfo Err { get; set; } = new ErrorInfo();
        protected Order Order { get; set; } = new Order();
        protected EZDialogYesNo DeleteModal { get; set; }
        protected EZDialogOk WarningModal { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (OrderId != 0)
            {
                Order = await OrderService.GetOrder(OrderId, Err);
                if (Order.CustomerId != CustomerId)
                {
                    //kan niet
                }
            }
            else
            {
                Order.CustomerId = CustomerId;
            }
        }

        protected async Task HandleValidSubmit()
        {
            Order result;
            if (Order.OrderId != 0)
            {
                result = await OrderService.UpdateOrder(Order, Err);
            }
            else
            {
                result = await OrderService.CreateOrder(Order, Err);
                //NavigationManager.NavigateTo($"/RelationMaintain/{result.RelationId}");
            }
            if (Err.Code != null)
            {

            }
            Order = result;
        }

        protected async Task HandleUndoChange()
        {
            if (OrderId != 0)
            {
                Order = await OrderService.GetOrder(OrderId, Err);
                if (Order.CustomerId != CustomerId)
                {
                    //kan niet
                }
            }
            else
            {
                Order.CustomerId = CustomerId;
            }
        }

        protected void HandleDelete() =>
            DeleteModal.Show();

        protected async Task HandleDeleteConfirm(bool deleteConfirm)
        {
            if (deleteConfirm)
            {
                if (await OrderService.DeleteOrder(Order.OrderId, Err))
                {
                    
                }
                else
                {
                    WarningModal.Show();
                }
            }
        }
    }
}
