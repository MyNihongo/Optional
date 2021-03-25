using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;

namespace MyNihongo.Option.Tests.OptionalTests
{
	public sealed class EqualsShould
	{
		[Fact]
		public void ReturnTrueIfValueEqual()
		{
			Optional<int> item1 = 1, item2 = 1;

			var result = item1 == item2;

			result
				.Should()
				.BeTrue();
		}

		[Fact]
		public void ReturnFalseIfValueNotEqual()
		{
			Optional<int> item1 = 1, item2 = 2;

			var result = item1 == item2;

			result
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnFalseIfOneHasNoValue()
		{
			Optional<int> item1 = 1, item2 = Optional<int>.None();

			var result = item1 == item2;

			result
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnTrueIfBothNoValue()
		{
			Optional<int> item1 = Optional<int>.None(), item2 = Optional<int>.None();

			var result = item1 == item2;

			result
				.Should()
				.BeTrue();
		}

		[Fact]
		public void ReturnFalseIfNull()
		{
			var result = Optional<int>.None()
				.Equals(null);

			result
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnFalseIfNotOptional()
		{
			// ReSharper disable once SuspiciousTypeConversion.Global
			var result = Optional<int>.None()
				.Equals(new Optional<string>());

			result
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnTrueIfEqualValue()
		{
			const int value = 123;
			object input = value.AsOptional();

			var result = Optional<int>.Of(value)
				.Equals(input);

			result
				.Should()
				.BeTrue();
		}

		[Fact]
		public void ReturnFalseIfNotEqualValue()
		{
			object input = 123.AsOptional();

			var result = Optional<int>.Of(321)
				.Equals(input);

			result
				.Should()
				.BeFalse();
		}
	}
}
