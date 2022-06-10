namespace MyNihongo.Option.Tests.OptionalTests;

public sealed class GetHashCodeShould
{
	[Fact]
	public void ReturnZeroIfNoValue()
	{
		var result = Optional<int>.None()
			.GetHashCode();

		result
			.Should()
			.Be(0);
	}

	[Fact]
	public void ComputeHashCode()
	{
		var result = 123.AsOptional()
			.GetHashCode();

		result
			.Should()
			.Be(882);
	}
}
