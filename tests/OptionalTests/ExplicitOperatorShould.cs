using System;
using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;

namespace MyNihongo.Option.Tests.OptionalTests
{
	public sealed class ExplicitOperatorShould
	{
		[Fact]
		public void ConvertToTypeExplicitly()
		{
			const int value = 123;
			var optional = value.AsOptional();

			var result = (int)optional;

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ThrowExceptionIfNoValueWhenConvertingToType()
		{
			var optional = Optional<int>.None();

			Action action = () => { var _ = (int) optional; };

#if NET5_0
			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
#elif NET40
			action
				.ShouldThrowExactly<InvalidOperationException>();
#endif
		}
	}
}
