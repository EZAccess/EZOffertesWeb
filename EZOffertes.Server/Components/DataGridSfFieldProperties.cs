using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Components
{
    public class DataGridSfFieldProperties
    {
        public string Field { get; set; }
        public string HeaderText { get; set; }
        public string TextAlign { get; set; } = "TextAlign.Left";
        public string Width { get; set; } = "Auto";
        public string DisplayAsCheckbox { get; set; } = "false";
        public string IsPrimaryKey { get; set; } = "false";
        public string IsIdentity { get; set; } = "false";
    }
}
