namespace MyNihongo.Option.Tests.OptionalTests;

public class JsonSerializationShould
{
#if !NET40
	[Fact]
	public void SerializeWithOptionalProps()
	{
		const string expected = @"{""Id"":123,""Name"":""Name"",""Salary"":{""HasValue"":false},""IsMarried"":true}";

		var fixture = new RecordWithProps
		{
			Id = 123,
			Name = "Name",
			IsMarried = true
		};

		var result = JsonSerializer.Serialize(fixture);

		result
			.Should()
			.Be(expected);
	}
#endif
}
