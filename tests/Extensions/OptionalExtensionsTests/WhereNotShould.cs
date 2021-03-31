using System;
using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;
// ReSharper disable ExpressionIsAlwaysNull

namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests
{
	public sealed class WhereNotShould
	{
		[Fact]
		public void ThrowExceptionIfNull()
		{
			Func<Class, bool> func = null;

			Action action = () => Optional<Class>.None()
				.WhereNot(func);

			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}

		[Fact]
		public void ReturnNoneIfNoValue()
		{
			var result = Optional<Class>.None()
				.WhereNot(x => x.Id == 0);

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnValueIfPredicateFalse()
		{
			const int id = 1;
			var input = new Class { Id = id };

			var result = input.AsOptional()
				.WhereNot(x => x.Id != id);

			result.Value
				.Should()
				.Be(input);
		}

		[Fact]
		public void ReturnNoneIfPredicateTrue()
		{
			const int id = 1;
			var input = new Class { Id = id };

			var result = input.AsOptional()
				.WhereNot(x => x.Id == id);

			result.HasValue
				.Should()
				.BeFalse();
		}
	}
}
