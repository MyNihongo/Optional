using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;

namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests
{
	public sealed class ValueOrNullShould
	{
		[Fact]
		public void ReturnValueIfHasValue()
		{
			var input = new Struct(123);

			var result = Optional<Struct>.Of(input)
				.ValueOrNull();

			result
				.Should()
				.Be(input);
		}

		[Fact]
		public void ReturnNullIfNoValue()
		{
			var result = Optional<Struct>.None()
				.ValueOrNull();

			result
				.Should()
				.BeNull();
		}
	}
}
