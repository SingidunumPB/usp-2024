using Ardalis.SmartEnum;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace USP.Application.Common.Extensions;

public class SmartEnumSerializer<TEnum, TValue> : SerializerBase<TEnum>
    where TEnum : SmartEnum<TEnum, TValue>
    where TValue : IEquatable<TValue>, IComparable<TValue>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TEnum value)
    {
        context.Writer.WriteString(value.Name);
    }

    public override TEnum Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var name = context.Reader.ReadString();
        return SmartEnum<TEnum, TValue>.FromName(name);
    }
}