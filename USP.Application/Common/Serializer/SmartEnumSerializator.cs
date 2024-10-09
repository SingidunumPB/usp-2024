using Ardalis.SmartEnum;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace USP.Application.Common.Serializer;

public class SmartEnumSerializer<TEnum, TValue> : SerializerBase<TEnum>
    where TEnum : SmartEnum<TEnum, TValue>
    where TValue : IEquatable<TValue>, IComparable<TValue>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TEnum value)
    {
        context.Writer.WriteStartDocument();
        context.Writer.WriteName("_t");
        context.Writer.WriteString(value.GetType().Name);
        context.Writer.WriteName("Name");
        context.Writer.WriteString(value.Name);
        context.Writer.WriteName("Value");
        context.Writer.WriteInt32(int.Parse(value.Value.ToString()!));
        context.Writer.WriteEndDocument();
    }

    public override TEnum Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        context.Reader.ReadStartDocument();
        context.Reader.ReadName("_t");
        var typeName = context.Reader.ReadString();
        context.Reader.ReadName("Name");
        var name = context.Reader.ReadString();
        context.Reader.ReadName("Value");
        var value = context.Reader.ReadInt32();
        context.Reader.ReadEndDocument();

        return SmartEnum<TEnum, TValue>.FromName(name);
    }
}
