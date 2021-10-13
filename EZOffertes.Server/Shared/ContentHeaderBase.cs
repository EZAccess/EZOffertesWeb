using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Shared
{
    public class ContentHeaderBase : ComponentBase
    {
        [Parameter]
        public string Caption { get; set; }
    }
}
