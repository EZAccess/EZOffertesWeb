using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Components
{
    public class EZDialogOkBase : ComponentBase
    {
        protected bool ShowDialog { get; set; }

        [Parameter]
        public string Caption { get; set; }

        [Parameter]
        public string Message { get; set; }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        protected void HandleClose()
        {
            ShowDialog = false;
        }

    }
}
