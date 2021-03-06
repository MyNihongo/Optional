using System;
using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;
// ReSharper disable ExpressionIsAlwaysNull

namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests
{
	public sealed class WhereShould
	{
		[Fact]
		public void ThrowExceptionIfNull()
		{
			Func<Class, bool> func = null;

			Action action = () => Optional<Class>.None()
				.Where(func);

#if NET5_0
			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
#elif NET40
			action
				.ShouldThrowExactly<ArgumentNullException>();
#endif
		}

		[Fact]
		public void ReturnNoneIfNoValue()
		{
			var result = Optional<Class>.None()
				.Where(x => x.Id == 0);

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnNoneIfPredicateFalse()
		{
			const int id = 1;
			var input = new Class { Id = id };

			var result = input.AsOptional()
				.Where(x => x.Id != id);

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnValueIfPredicateTrue()
		{
			const int id = 1;
			var input = new Class { Id = id };

			var result = input.AsOptional()
				.Where(x => x.Id == id);

			result.Value
				.Should()
				.Be(input);
		}
	}
}
