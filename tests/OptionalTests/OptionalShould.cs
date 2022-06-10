namespace MyNihongo.Option.Tests.OptionalTests;

public sealed class OptionalShould
{
	[Fact]
	public void HaveValue()
	{
		var result = Optional<string>.Of(null)
			.HasValue;

		result
			.Should()
			.BeTrue();
	}

	[Fact]
	public void NotHaveValue()
	{
		var result = Optional<string>.None()
			.HasValue;

		result
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnValue()
	{
		var result = Optional<string>.Of(null)
			.Value;

		result
			.Should()
			.BeNull();
	}
}
