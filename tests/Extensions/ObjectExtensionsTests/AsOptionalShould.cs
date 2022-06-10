namespace MyNihongo.Option.Tests.Extensions.ObjectExtensionsTests;

public sealed class AsOptionalShould
{
	[Fact]
	public void CreateOptional()
	{
		var values = new object[]
		{
			null,
			true,
			123,
			"string",
			123L,
			123d
		};

		foreach (var value in values)
		{
			var result = value.AsOptional();

			result.HasValue
				.Should()
				.BeTrue();

			result.Value
				.Should()
				.Be(value);

		}
	}
}
