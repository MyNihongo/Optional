using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;
// ReSharper disable AssignNullToNotNullAttribute

namespace MyNihongo.Option.Tests.Extensions.EnumerableExtensionsTests
{
	public sealed class MaxOrOptionalShould
	{
		[Fact]
		public void ThrowExceptionIfNull()
		{
			IEnumerable<string> input = null;

			Action action = () => input.MaxOrOptional();

			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}

		[Fact]
		public void ReturnNoneIfEmptyNullable()
		{
			var result = Enumerable.Empty<string>()
				.MaxOrOptional();

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnNoneIfEmptyNonNullable()
		{
			var result = Enumerable.Empty<int>()
				.MaxOrOptional();

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
				.MaxOrOptional();

			result.Value
				.Should()
				.Be(name);
		}

		[Fact]
		public void ReturnMaxValueNullable()
		{
			const string name1 = nameof(name1), name2 = nameof(name2), name3 = nameof(name3);

			var result = Enumerable.Empty<string>()
				.Append(name3)
				.Append(name1)
				.Append(name2)
				.MaxOrOptional();

			result.Value
				.Should()
				.Be(name3);
		}

		[Fact]
		public void ReturnMaxValueNonNullable()
		{
			const int id1 = 1, id2 = 2, id3 = 3;

			var result = Enumerable.Empty<int>()
				.Append(id3)
				.Append(id1)
				.Append(id2)
				.MaxOrOptional();

			result.Value
				.Should()
				.Be(id3);
		}

		[Fact]
		public void ThrowExceptionIfNullWithSelector()
		{
			IEnumerable<Class> input = null;

			Action action = () => input.MaxOrOptional(x => x.Name);

			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}

		[Fact]
		public void ThrowExceptionIfSelectorNull()
		{
			Action action = () => Enumerable.Empty<Class>()
				.MaxOrOptional<Class, string>(null);

			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}

		[Fact]
		public void ReturnNoneIfEmptyNullableWithSelector()
		{
			var result = Enumerable.Empty<Class>()
				.MaxOrOptional(x => x.Name);

			result.HasValue
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnNoneIfEmptyNonNullableWithSelector()
		{
			var result = Enumerable.Empty<Class>()
				.MaxOrOptional(x => x.Id);

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
				.Append(new Class { Name = "name" })
				.Append(null)
				.MaxOrOptional(x => x?.Name);

			result.Value
				.Should()
				.Be(name);
		}

		[Fact]
		public void ReturnMaxValueNullableWithSelector()
		{
			const string name1 = nameof(name1), name2 = nameof(name2), name3 = nameof(name3);

			var result = Enumerable.Empty<Class>()
				.Append(new Class { Name = name1 })
				.Append(new Class { Name = name3 })
				.Append(new Class { Name = name2 })
				.MaxOrOptional(x => x.Name);

			result.Value
				.Should()
				.Be(name3);
		}

		[Fact]
		public void ReturnMaxValueNonNullableWithSelector()
		{
			const int id1 = 1, id2 = 2, id3 = 3;

			var result = Enumerable.Empty<Class>()
				.Append(new Class { Id = id1 })
				.Append(new Class { Id = id3 })
				.Append(new Class { Id = id2 })
				.MaxOrOptional(x => x.Id);

			result.Value
				.Should()
				.Be(id3);
		}
	}
}
