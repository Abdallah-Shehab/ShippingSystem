using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Enums
{
    public enum OrderStatus
    {


        Canceled,
        RefusedWithPayment,
        RefusedWithoutPayment,
        RefusedWithPartialPayment,
        DeliveredToDelivery,
        Delivered, // Typo: Should be Delivered
        PartiallyDelivered,
        Suspended,
        NotReachable, // Typo: Should be NotReachable
        Waiting
    }
}
