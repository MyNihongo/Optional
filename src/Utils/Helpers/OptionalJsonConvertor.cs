namespace MyNihongo.Option;

#if !NET40
internal sealed class OptionalJsonConvertor<T> : JsonConverter<Optional<T>>
{
	public override Optional<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException();
	}

	public override void Write(Utf8JsonWriter writer, Optional<T> value, JsonSerializerOptions options)
	{
		if (value.HasValue)
		{
			var valueString = JsonSerializer.Serialize(value.Value);
			writer.WriteRawValue(valueString);
		}
		else
		{
			writer.WriteStartObject();
			writer.WriteBoolean(nameof(Optional<T>.HasValue), value.HasValue);
			writer.WriteEndObject();
		}
	}
}
#endif
