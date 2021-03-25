using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;

namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests
{
	public sealed class ValueOrShould
	{
		[Fact]
		public void ReturnValue()
		{
			const int value = 123, anotherValue = value * 2;

			var result = Optional<int>.Of(value)
				.ValueOr(anotherValue);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnFallbackValue()
		{
			const int value = 123, anotherValue = value * 2;

			var result = Optional<int>.None()
				.ValueOr(anotherValue);

			result
				.Should()
				.Be(anotherValue);
		}
	}
}
