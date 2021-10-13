using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public enum ShippingStatus
    {
        Non = 0,
        OnStock = 1,
        Picked = 2,
        Shipped = 3,
        Delivered = 4
    }
}
