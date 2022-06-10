namespace MyNihongo.Option.Tests.OptionalTests;

public sealed class NotEqualsShould
{
	[Fact]
	public void ReturnFalseIfValueEqual()
	{
		Optional<int> item1 = 1, item2 = 1;

		var result = item1 != item2;

		result
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnTrueIfValueNotEqual()
	{
		Optional<int> item1 = 1, item2 = 2;

		var result = item1 != item2;

		result
			.Should()
			.BeTrue();
	}

	[Fact]
	public void ReturnTrueIfOneHasNoValue()
	{
		Optional<int> item1 = 1, item2 = Optional<int>.None();

		var result = item1 != item2;

		result
			.Should()
			.BeTrue();
	}

	[Fact]
	public void ReturnFalseIfBothNoValue()
	{
		Optional<int> item1 = Optional<int>.None(), item2 = Optional<int>.None();

		var result = item1 != item2;

		result
			.Should()
			.BeFalse();
	}
}
