﻿// ReSharper disable AssignNullToNotNullAttribute
namespace MyNihongo.Option.Tests.Extensions.EnumerableExTests;

public sealed class SingleOrOptionalShould
{
	[Fact]
	public void ThrowExceptionIfNull()
	{
		IEnumerable<Class> input = null;

		Action action = () => input.SingleOrOptional();
		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void ReturnNoneIfEmptyEnumerable()
	{
		var result = Enumerable.Empty<Class>()
			.SingleOrOptional();

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnNoneIfEmptyList()
	{
		var result = Arrays.Empty<Class>()
			.SingleOrOptional();

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnSingleIfEnumerable()
	{
		Class item = new() { Id = 1, Name = "name" };

		var result = new [] { item }
			.AsEnumerable()
			.SingleOrOptional();

		result.Value
			.Should()
			.Be(item);
	}

	[Fact]
	public void ReturnSingleIfList()
	{
		Class item = new() { Id = 1, Name = "name" };

		var result = new[] { item }
			.SingleOrOptional();

		result.Value
			.Should()
			.Be(item);
	}

	[Fact]
	public void ThrowExceptionIfNotSingleEnumerable()
	{
		Class item1 = new() { Id = 1, Name = "name" },
			item2 = new() { Id = 1, Name = "name" };

		Action action = () => new[] { item1, item2 }
			.AsEnumerable()
			.SingleOrOptional();

		action.ShouldThrow<InvalidOperationException>();
	}

	[Fact]
	public void ThrowExceptionIfNotSingleList()
	{
		Class item1 = new() { Id = 1, Name = "name" },
			item2 = new() { Id = 1, Name = "name" };

		Action action = () => new[] { item1, item2 }
			.SingleOrOptional();

		action.ShouldThrow<InvalidOperationException>();
	}

	[Fact]
	public void ThrowExceptionWithPredicateIfNull()
	{
		IEnumerable<Class> input = null;

		Action action = () => input.SingleOrOptional(x => x.Id > 0);
		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void ThrowExceptionWithPredicateIfPredicateNull()
	{
		Action action = () => Enumerable.Empty<Class>()
			.SingleOrOptional(null);

		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void ReturnNoneWithPredicateIfEmpty()
	{
		var result = Enumerable.Empty<Class>()
			.SingleOrOptional(x => x.Id > 0);

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnNoneWithPredicateIfNothingMatches()
	{
		Class item1 = new() { Id = 1, Name = "name" },
			item2 = new() { Id = 1, Name = "name" };

		var result = new[] { item1, item2 }
			.SingleOrOptional(x => x.Id == 2);

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnNoneWithPredicateIfSingleMatches()
	{
		const int id = 1;
		const string name = nameof(name);

		Class item1 = new() { Id = id, Name = name + "2" },
			item2 = new() { Id = id, Name = name };

		var result = new[] { item1, item2 }
			.SingleOrOptional(x => x.Id == id && x.Name == name);

		result.Value
			.Should()
			.Be(item2);
	}

	[Fact]
	public void ThrowExceptionIfManyFound()
	{
		const int id = 1;
		const string name = nameof(name);

		Class item1 = new() { Id = id, Name = name },
			item2 = new() { Id = id, Name = name };

		Action action = () => new[] { item1, item2 }
			.SingleOrOptional(x => x.Id == id && x.Name == name);

		action.ShouldThrow<InvalidOperationException>();
	}
}
