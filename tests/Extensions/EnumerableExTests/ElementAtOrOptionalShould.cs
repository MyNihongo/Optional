﻿// ReSharper disable AssignNullToNotNullAttribute
namespace MyNihongo.Option.Tests.Extensions.EnumerableExTests;

public sealed class ElementAtOrOptionalShould
{
	[Fact]
	public void ThrowExceptionIfNull()
	{
		IEnumerable<Class> input = null;

		Action action = () => input.ElementAtOrOptional(0);
		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void ReturnNoneIfIndexNegative()
	{
		var result = Enumerable.Empty<Class>()
			.ElementAtOrOptional(-1);

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnNoneIfEmptyEnumerable()
	{
		var result = Enumerable.Empty<Class>()
			.ElementAtOrOptional(0);

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnNoneIfEmptyList()
	{
		var result = Arrays.Empty<Class>()
			.ElementAtOrOptional(0);

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnNoneIfIndexExceedsEnumerableCount()
	{
		Class item1 = new() { Id = 2, Name = "name" },
			item2 = new() { Id = 1, Name = "name" },
			item3 = new() { Id = 1, Name = "name" };

		var result = new[] { item1, item2, item3 }
			.AsEnumerable()
			.ElementAtOrOptional(3);

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnNoneIfIndexExceedsListCount()
	{
		Class item1 = new() { Id = 2, Name = "name" },
			item2 = new() { Id = 1, Name = "name" },
			item3 = new() { Id = 1, Name = "name" };

		var result = new[] { item1, item2, item3 }
			.ElementAtOrOptional(3);

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnElementAtEnumerableIndex()
	{
		Class item1 = new() { Id = 2, Name = "name" },
			item2 = new() { Id = 1, Name = "name" },
			item3 = new() { Id = 1, Name = "name" };

		var result = new[] { item1, item2, item3 }
			.AsEnumerable()
			.ElementAtOrOptional(1);

		result.Value
			.Should()
			.Be(item2);
	}

	[Fact]
	public void ReturnElementAtListIndex()
	{
		Class item1 = new() { Id = 2, Name = "name" },
			item2 = new() { Id = 1, Name = "name" },
			item3 = new() { Id = 1, Name = "name" };

		var result = new[] { item1, item2, item3 }
			.ElementAtOrOptional(1);

		result.Value
			.Should()
			.Be(item2);
	}
}
