namespace MyNihongo.Option;

#if !NET40
internal sealed class OptionalJsonConvertorFactory : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
	{
		if (!typeToConvert.IsGenericType)
			return false;

		var typeDefinition = typeToConvert.GetGenericTypeDefinition();
		return typeof(Optional<>) == typeDefinition;
	}

	public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		var genericArgument = typeToConvert.GenericTypeArguments[0];
		var generic = typeof(OptionalJsonConvertor<>);
		generic = generic.MakeGenericType(genericArgument);

		return (JsonConverter?)Activator.CreateInstance(generic);
	}
}
#endif
