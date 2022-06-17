using System.Runtime.Serialization;

namespace JustSports.Core.Enum
{
    public enum OrderStatusEnum
    {
        Pending = 1,
        PaymentReceived = 2,
        PaymentFailed = 3,
        Delivered = 4,
        Cancelled = 5
    }
}