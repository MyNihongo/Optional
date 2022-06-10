// ReSharper disable AssignNullToNotNullAttribute
namespace MyNihongo.Option.Tests.Extensions.EnumerableExtensionsTests;

public sealed class MaxOrOptionalShould
{
	[Fact]
	public void ThrowExceptionIfNull()
	{
		IEnumerable<string> input = null;

		Action action = () => input.MaxOrOptional();
		action.ShouldThrow<ArgumentNullException>();
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

		var result = new[] { null, name, null }
			.MaxOrOptional();

		result.Value
			.Should()
			.Be(name);
	}

	[Fact]
	public void ReturnMaxValueNullable()
	{
		const string name1 = nameof(name1), name2 = nameof(name2), name3 = nameof(name3);

		var result = new[] { name3, name1, name2 }
			.MaxOrOptional();

		result.Value
			.Should()
			.Be(name3);
	}

	[Fact]
	public void ReturnMaxValueNonNullable()
	{
		const int id1 = 1, id2 = 2, id3 = 3;

		var result = new[] { id3, id1, id2 }
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
		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void ThrowExceptionIfSelectorNull()
	{
		Action action = () => Enumerable.Empty<Class>()
			.MaxOrOptional<Class, string>(null);

		action.ShouldThrow<ArgumentNullException>();
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

		var result = new[] { new Class(), new Class { Name = "name" }, null }
			.AsEnumerable()
			.MaxOrOptional(x => x?.Name);

		result.Value
			.Should()
			.Be(name);
	}

	[Fact]
	public void ReturnMaxValueNullableWithSelector()
	{
		const string name1 = nameof(name1), name2 = nameof(name2), name3 = nameof(name3);

		var result = new[] { new Class { Name = name1 }, new Class { Name = name3 }, new Class { Name = name2 } }
			.AsEnumerable()
			.MaxOrOptional(x => x.Name);

		result.Value
			.Should()
			.Be(name3);
	}

	[Fact]
	public void ReturnMaxValueNonNullableWithSelector()
	{
		const int id1 = 1, id2 = 2, id3 = 3;

		var result = new[] { new Class { Id = id1 }, new Class { Id = id3 }, new Class { Id = id2 } }
			.AsEnumerable()
			.MaxOrOptional(x => x.Id);

		result.Value
			.Should()
			.Be(id3);
	}
}
