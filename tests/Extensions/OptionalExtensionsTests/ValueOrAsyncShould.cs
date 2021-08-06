using System.Threading.Tasks;
using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;

namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests
{
#if NET5_0
	public sealed class ValueOrAsyncShould
	{
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
	}
#endif
}
