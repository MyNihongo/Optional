using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;
// ReSharper disable AssignNullToNotNullAttribute

namespace MyNihongo.Option.Tests.Extensions.EnumerableExtensionsTests
{
	public sealed class FirstOrOptionalShould
	{
		[Fact]
		public void ThrowExceptionIfNull()
		{
			IEnumerable<Class> input = null;

			Action action = () => input.FirstOrOptional();

			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}
		
		[Fact]
		public void ReturnNoneIfEmptyEnumerable()
		{
			var result = Enumerable.Empty<Class>()
				.FirstOrOptional();

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnNoneIfEmptyList()
		{
			var result = Array.Empty<Class>()
				.FirstOrOptional();

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnFirstItemIfEnumerable()
		{
			Class item1 = new() { Id = 1, Name = "name" },
				item2 = new() { Id = 1, Name = "name" };

			var result = Enumerable.Empty<Class>()
				.Append(item1)
				.Append(item2)
				.FirstOrOptional();

			result.Value
				.Should()
				.Be(item1);
		}

		[Fact]
		public void ReturnFirstItemIfList()
		{
			Class item1 = new() { Id = 1, Name = "name" },
				item2 = new() { Id = 1, Name = "name" };

			var result = new[] { item1, item2 }
				.FirstOrOptional();

			result.Value
				.Should()
				.Be(item1);
		}

		[Fact]
		public void ThrowExceptionIfNullWithPredicate()
		{
			IEnumerable<Class> input = null;

			Action action = () => input.FirstOrOptional(x => x.Id > 0);

			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}

		[Fact]
		public void ThrowExceptionIfPredicateNull()
		{
			Action action = () => Enumerable.Empty<Class>()
				.FirstOrOptional(null);

			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}

		[Fact]
		public void ReturnNoneWithPredicateIfEmpty()
		{
			var result = Enumerable.Empty<Class>()
				.FirstOrOptional(x => x.Id > 0);

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnFirstItemWithPredicate()
		{
			const int id = 1;

			Class item1 = new() { Id = 2, Name = "name" },
				item2 = new() { Id = id, Name = "name" },
				item3 = new() { Id = id, Name = "name" };

			var result = new[] { item1, item2, item3 }
				.FirstOrOptional(x => x.Id == id);

			result.Value
				.Should()
				.Be(item2);
		}

		[Fact]
		public void ReturnNoneWithPredicateIfNothingMatches()
		{
			Class item1 = new() { Id = 2, Name = "name" },
				item2 = new() { Id = 1, Name = "name" },
				item3 = new() { Id = 1, Name = "name" };

			var result = new[] { item1, item2, item3 }
				.FirstOrOptional(x => x.Id == int.MaxValue);

			result.HasValue
				.Should()
				.BeFalse();
		}
	}
}
