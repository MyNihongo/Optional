namespace MyNihongo.Option.Tests.OptionalTests;

public class JsonSerializationShould
{
#if !NET40
	[Fact]
	public void SerializeWithOptionalProps()
	{
		var fixture = new RecordWithProps
		{
			Id = 123,
			Name = "Name"
		};

		JsonSerializer.Serialize(fixture);
	}
#endif
}
