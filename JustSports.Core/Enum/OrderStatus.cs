using System.Runtime.Serialization;

namespace JustSports.Core.Enum
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending, 

        [EnumMember(Value = "PaymentReceived")]
        PaymentReceived, 
        
        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed

    }
}