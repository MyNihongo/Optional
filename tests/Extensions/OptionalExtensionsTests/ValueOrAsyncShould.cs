namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests;
public sealed class ValueOrAsyncShould
{
#if !NET40
	[Fact]
	public async Task ReturnValueIfHasValue()
	{
		const int value = 123, fallbackValue = -value;

		var result = await ValueTask.FromResult(Optional<int>.Of(value))
			.ValueOrAsync(fallbackValue);

		result
			.Should()
			.Be(value);
	}

	[Fact]
	public async Task ReturnFallbackValueIfNoValue()
	{
		const int value = 123, fallbackValue = -value;

		var result = await ValueTask.FromResult(Optional<int>.None())
			.ValueOrAsync(fallbackValue);

		result
			.Should()
			.Be(fallbackValue);
	}
#endif
}
