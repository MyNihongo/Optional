using System;
using FluentAssertions;
using Xunit;

namespace MyNihongo.Option.Tests.OptionalTests
{
	public sealed class ImplicitOperatorShould
	{
		[Fact]
		public void ThrowExceptionIfNoValue()
		{
			Func<string> action = () => Optional<string>.None().Value;

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ConvertToOptional()
		{
			const int value = 123;
			Optional<int> result = value;

			result.HasValue
				.Should()
				.BeTrue();

			result.Value
				.Should()
				.Be(value);
		}
	}
}
