namespace MyNihongo.Option.Tests.OptionalTests;

public sealed class ExplicitOperatorShould
{
	[Fact]
	public void ConvertToTypeExplicitly()
	{
		const int value = 123;
		var optional = value.AsOptional();

		var result = (int)optional;

		result
			.Should()
			.Be(value);
	}

	[Fact]
	public void ThrowExceptionIfNoValueWhenConvertingToType()
	{
		var optional = Optional<int>.None();

		var action = () => { var _ = (int) optional; };
		action.ShouldThrow<InvalidOperationException>();
	}
}
