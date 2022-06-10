// ReSharper disable ExpressionIsAlwaysNull
namespace MyNihongo.Option.Tests.Extensions.ObjectExTests;

public sealed class AsNonNullOptionalShould
{
	[Fact]
	public void ReturnResultIfNotNull()
	{
		var input = new Class();

		var result = input.AsNonNullOptional();

		result.HasValue
			.Should()
			.BeTrue();

		result.Value
			.Should()
			.Be(input);
	}

	[Fact]
	public void ReturnNoneIfNull()
	{
		Class input = null;

		var result = input.AsNonNullOptional();

		result.HasValue
			.Should()
			.BeFalse();
	}
}
