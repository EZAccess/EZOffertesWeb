using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public enum InvoiceStatus
    {
        Concept = 0,
        Send = 1,
        Paid = 2,
        Reminded = 3,
        Warned = 4,
        Trouble = 5,
        Deleted = 9
    }
}
