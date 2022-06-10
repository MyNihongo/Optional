namespace MyNihongo.Option.Tests.Extensions.OptionalExTests;

public sealed class ConvertOrShould
{
	[Fact]
	public void ConvertValue()
	{
		const int value = 123, anotherValue = value * 2;

		var result = Optional<Class>.Of(new Class { Id = value })
			.ConvertOr(x => x.Id, anotherValue);

		result
			.Should()
			.Be(value);
	}

	[Fact]
	public void ConvertFallbackValue()
	{
		const int value = 123, anotherValue = value * 2;

		var result = Optional<Class>.None()
			.ConvertOr(x => x.Id, anotherValue);

		result
			.Should()
			.Be(anotherValue);
	}
}
