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
			Action action = () => { var _ = Optional<string>.None().Value; };

#if NET5_0
			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
#elif NET40
			action
				.ShouldThrowExactly<InvalidOperationException>();
#endif
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
