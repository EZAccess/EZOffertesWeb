using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Components
{
    public class DataGridSfInfo
    {
        public string AllowFiltering { get; set; } = "false";
        public string[] ToolbarItems { get; set; }
        public List<DataGridSfFieldProperties> FieldProperties { get; set; }
    }
}
