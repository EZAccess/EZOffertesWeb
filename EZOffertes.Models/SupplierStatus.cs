using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public enum SupplierStatus
    {
        Non = 0,
        PrepareForOrder = 1,
        Ordered = 2,
        Confirmed = 3,
        Delivered = 4
    }
}
