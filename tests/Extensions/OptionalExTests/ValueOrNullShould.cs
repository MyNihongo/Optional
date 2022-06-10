namespace MyNihongo.Option.Tests.Extensions.OptionalExTests;

public sealed class ValueOrNullShould
{
	[Fact]
	public void ReturnValueIfHasValue()
	{
		var input = new Struct(123);

		var result = Optional<Struct>.Of(input)
			.ValueOrNull();

		result
			.Should()
			.Be(input);
	}

	[Fact]
	public void ReturnNullIfNoValue()
	{
		var result = Optional<Struct>.None()
			.ValueOrNull();

		result
			.Should()
			.BeNull();
	}
}
