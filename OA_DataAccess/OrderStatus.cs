using System;
using System.Collections.Generic;
using System.Text;

namespace OA_DataAccess
{
    /// <summary>
    /// Order status
    /// </summary>
    public enum OrderStatus
    {
        NewOrder,
        CanceledByAdministrator,
        PaymentReceived,
        Sent,
        Received,
        Completed,
        CanceledByUser
    }
}
