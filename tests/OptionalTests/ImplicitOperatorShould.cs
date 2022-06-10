namespace MyNihongo.Option.Tests.OptionalTests;

public sealed class ImplicitOperatorShould
{
	[Fact]
	public void ThrowExceptionIfNoValue()
	{
		var action = () => { var _ = Optional<string>.None().Value; };
		action.ShouldThrow<InvalidOperationException>();
	}

	[Fact]
	public void ConvertToOptional()
	{
		const int value = 123;
		Optional<int> result = value;

		result.HasValue
			.Should()
			.BeTrue();

		result.Value
			.Should()
			.Be(value);
	}
}
