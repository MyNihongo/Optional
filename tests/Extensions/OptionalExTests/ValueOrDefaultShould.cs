namespace MyNihongo.Option.Tests.Extensions.OptionalExTests;

public sealed class ValueOrDefaultShould
{
	[Fact]
	public void ReturnValues()
	{
		var values = new object[]
		{
			"string",
			(byte) 123,
			(short) 123,
			123,
			123L,
			123d,
			123UL,
			123f,
			true
		};

		foreach (var value in values)
		{
			var result = value.AsOptional()
				.ValueOrDefault();

			result
				.Should()
				.Be(value);
		}
	}

	[Fact]
	public void ReturnZeroForByte()
	{
		var result = Optional<byte>.None()
			.ValueOrDefault();

		result
			.Should()
			.Be(0);
	}

	[Fact]
	public void ReturnNullOfString()
	{
		var result = Optional<string>.None()
			.ValueOrDefault();

		result
			.Should()
			.BeNull();
	}
}
