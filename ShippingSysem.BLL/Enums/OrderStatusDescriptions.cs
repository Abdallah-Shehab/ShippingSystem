using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Enums
{
    public static class OrderStatusDescriptions
    {
        public static readonly Dictionary<OrderStatus, string> StatusDescriptions = new Dictionary<OrderStatus, string>
    {
        { OrderStatus.Canceled, "تم الرفض" },
        { OrderStatus.RefusedWithPayment, "تم الرفض مع الدفع" },
        { OrderStatus.RefusedWithoutPayment, "رفض مع عدم الدفع" },
        { OrderStatus.RefusedWithPartialPayment, "رفض مع سداد جزء" },
        { OrderStatus.DeliveredToDelivery, "تم التسليم للمندوب" },
        { OrderStatus.Delivered, "تم التوصيل" }, // Corrected typo
        { OrderStatus.PartiallyDelivered, "تم التسليم جزئيا" },
        { OrderStatus.Suspended, "تم التأجيل" },
        { OrderStatus.NotReachable, "لا يمكن الوصول" }, // Corrected typo
        { OrderStatus.Waiting, "قيد الإنتظار" }
    };
    }
}
