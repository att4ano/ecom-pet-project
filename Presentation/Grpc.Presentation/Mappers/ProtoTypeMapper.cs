using Decimal = ProductGrpc.Decimal;

namespace Grpc.Presentation.Mappers;

public static class ProtoTypeMapper
{
    private const decimal Factor = 1_000_000;
    public static Guid ToGuid(this string guid)
    {
        return Guid.Parse(guid);
    }
    
    public static decimal ToDecimal(this Decimal number)
    {
        return number.Units + number.Nanos / Factor;
    }
    
    public static Decimal ToProto(this decimal number)
    {
        return new Decimal
        {
            Units = (int)Math.Floor(number),
            Nanos = (int)(number - (int)Math.Floor(number))
        };
    }
}