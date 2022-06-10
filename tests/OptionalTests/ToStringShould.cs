namespace MyNihongo.Option.Tests.OptionalTests;

public sealed class ToStringShould
{
	[Fact]
	public void ReturnStringValue()
	{
		var result = 123.AsOptional()
			.ToString();

		result
			.Should()
			.Be("123");
	}

	[Fact]
	public void ReturnEmptyStringIfNull()
	{
		var result = Optional<int?>.Of(null)
			.ToString();

		result
			.Should()
			.BeEmpty();
	}

	[Fact]
	public void ReturnNoneIfNoValue()
	{
		var result = Optional<int>.None()
			.ToString();

		result
			.Should()
			.Be("<None>");
	}
}
