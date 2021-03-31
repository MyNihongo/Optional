using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;

namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests
{
	public sealed class ValueOrDefaultShould
	{
		[Theory]
		[InlineData("string")]
		[InlineData((byte)123)]
		[InlineData((short)123)]
		[InlineData(123)]
		[InlineData(123L)]
		[InlineData(123d)]
		[InlineData(123UL)]
		[InlineData(123f)]
		[InlineData(true)]
		public void ReturnValues(object value)
		{
			var result = value.AsOptional()
				.ValueOrDefault();

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnZeroForByte()
		{
			var result = Optional<byte>.None()
				.ValueOrDefault();

			result
				.Should()
				.Be(0);
		}

		[Fact]
		public void ReturnNullOfString()
		{
			var result = Optional<string>.None()
				.ValueOrDefault();

			result
				.Should()
				.BeNull();
		}
	}
}
