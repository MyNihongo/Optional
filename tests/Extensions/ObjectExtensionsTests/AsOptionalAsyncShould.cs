namespace MyNihongo.Option.Tests.Extensions.ObjectExtensionsTests;

public sealed class AsOptionalAsyncShould
{
#if !NET40
	[Theory]
	[InlineData(null)]
	[InlineData(true)]
	[InlineData(123)]
	[InlineData("string")]
	[InlineData(123L)]
	[InlineData(123d)]
	public async Task CreateOptional(object input)
	{
		var result = await input.AsOptionalAsync();

		result.HasValue
			.Should()
			.BeTrue();

		result.Value
			.Should()
			.Be(input);
	}

	[Theory]
	[InlineData(null)]
	[InlineData(true)]
	[InlineData(123)]
	[InlineData("string")]
	[InlineData(123L)]
	[InlineData(123d)]
	public async Task ConvertValueTaskToOptional(object input)
	{
		var result = await new ValueTask<object>(input)
			.AsOptionalAsync();

		result.HasValue
			.Should()
			.BeTrue();

		result.Value
			.Should()
			.Be(input);
	}

	[Theory]
	[InlineData(null)]
	[InlineData(true)]
	[InlineData(123)]
	[InlineData("string")]
	[InlineData(123L)]
	[InlineData(123d)]
	public async Task ConvertTaskToOptional(object input)
	{
		var result = await Task.FromResult(input)
			.AsOptionalAsync();

		result.HasValue
			.Should()
			.BeTrue();

		result.Value
			.Should()
			.Be(input);
	}
#endif
}
