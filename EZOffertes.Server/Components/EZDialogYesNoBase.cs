using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Components
{
    public class EZDialogYesNoBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter]
        public string Caption { get; set; }

        [Parameter]
        public string Message { get; set; }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        protected async Task HandleConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }

    }
}
