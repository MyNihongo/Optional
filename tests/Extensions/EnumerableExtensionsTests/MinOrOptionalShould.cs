using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;
// ReSharper disable AssignNullToNotNullAttribute

namespace MyNihongo.Option.Tests.Extensions.EnumerableExtensionsTests
{
	public sealed class MinOrOptionalShould
	{
		[Fact]
		public void ThrowExceptionIfNull()
		{
			IEnumerable<string> input = null;

			Action action = () => input.MinOrOptional();

			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}

		[Fact]
		public void ReturnNoneIfEmptyNullable()
		{
			var result = Enumerable.Empty<string>()
				.MinOrOptional();

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnNoneIfEmptyNonNullable()
		{
			var result = Enumerable.Empty<int>()
				.MinOrOptional();

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void NotCompareNullValues()
		{
			const string name = nameof(name);

			var result = Enumerable.Empty<string>()
				.Append(null)
				.Append(name)
				.Append(null)
				.MinOrOptional();

			result.Value
				.Should()
				.Be(name);
		}

		[Fact]
		public void ReturnMinValueNullable()
		{
			const string name1 = nameof(name1), name2 = nameof(name2), name3 = nameof(name3);

			var result = Enumerable.Empty<string>()
				.Append(name3)
				.Append(name1)
				.Append(name2)
				.MinOrOptional();

			result.Value
				.Should()
				.Be(name1);
		}

		[Fact]
		public void ReturnMinValueNonNullable()
		{
			const int id1 = 1, id2 = 2, id3 = 3;

			var result = Enumerable.Empty<int>()
				.Append(id3)
				.Append(id1)
				.Append(id2)
				.MinOrOptional();

			result.Value
				.Should()
				.Be(id1);
		}

		[Fact]
		public void ThrowExceptionIfNullWithSelector()
		{
			IEnumerable<Class> input = null;

			Action action = () => input.MinOrOptional(x => x.Name);

			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}

		[Fact]
		public void ThrowExceptionIfSelectorNull()
		{
			Action action = () => Enumerable.Empty<Class>()
				.MinOrOptional<Class, string>(null);

			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}

		[Fact]
		public void ReturnNoneIfEmptyNullableWithSelector()
		{
			var result = Enumerable.Empty<Class>()
				.MinOrOptional(x => x.Name);

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnNoneIfEmptyNonNullableWithSelector()
		{
			var result = Enumerable.Empty<Class>()
				.MinOrOptional(x => x.Id);

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void NotCompareNullValuesWithSelector()
		{
			const string name = nameof(name);

			var result = Enumerable.Empty<Class>()
				.Append(new Class())
				.Append(new Class { Name = "name"})
				.Append(null)
				.MinOrOptional(x => x?.Name);

			result.Value
				.Should()
				.Be(name);
		}

		[Fact]
		public void ReturnMinValueNullableWithSelector()
		{
			const string name1 = nameof(name1), name2 = nameof(name2), name3 = nameof(name3);

			var result = Enumerable.Empty<Class>()
				.Append(new Class { Name = name3})
				.Append(new Class { Name = name1})
				.Append(new Class { Name = name2})
				.MinOrOptional(x => x.Name);

			result.Value
				.Should()
				.Be(name1);
		}

		[Fact]
		public void ReturnMinValueNonNullableWithSelector()
		{
			const int id1 = 1, id2 = 2, id3 = 3;

			var result = Enumerable.Empty<Class>()
				.Append(new Class { Id = id3 })
				.Append(new Class { Id = id1 })
				.Append(new Class { Id = id2 })
				.MinOrOptional(x => x.Id);

			result.Value
				.Should()
				.Be(id1);
		}
	}
}
