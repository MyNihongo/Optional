// ReSharper disable AssignNullToNotNullAttribute
namespace MyNihongo.Option.Tests.Extensions.EnumerableExtensionsTests;

public sealed class MinOrOptionalShould
{
	[Fact]
	public void ThrowExceptionIfNull()
	{
		IEnumerable<string> input = null;

		Action action = () => input.MinOrOptional();
		action.ShouldThrow<ArgumentNullException>();
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

		var result = new [] { null, name, null }
			.AsEnumerable()
			.MinOrOptional();

		result.Value
			.Should()
			.Be(name);
	}

	[Fact]
	public void ReturnMinValueNullable()
	{
		const string name1 = nameof(name1), name2 = nameof(name2), name3 = nameof(name3);

		var result = new[] { name3, name1, name2 }
			.AsEnumerable()
			.MinOrOptional();

		result.Value
			.Should()
			.Be(name1);
	}

	[Fact]
	public void ReturnMinValueNonNullable()
	{
		const int id1 = 1, id2 = 2, id3 = 3;

		var result = new[] { id3, id1, id2 }
			.AsEnumerable()
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
		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void ThrowExceptionIfSelectorNull()
	{
		Action action = () => Enumerable.Empty<Class>()
			.MinOrOptional<Class, string>(null);

		action.ShouldThrow<ArgumentNullException>();
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

		var result = new[] { new Class(), new Class { Name = name }, null }
			.AsEnumerable()
			.MinOrOptional(x => x?.Name);

		result.Value
			.Should()
			.Be(string.Empty);
	}

	[Fact]
	public void ReturnMinValueNullableWithSelector()
	{
		const string name1 = nameof(name1), name2 = nameof(name2), name3 = nameof(name3);

		var result = new[] { new Class { Name = name1 }, new Class { Name = name3 }, new Class { Name = name2 } }
			.AsEnumerable()
			.MinOrOptional(x => x.Name);

		result.Value
			.Should()
			.Be(name1);
	}

	[Fact]
	public void ReturnMinValueNonNullableWithSelector()
	{
		const int id1 = 1, id2 = 2, id3 = 3;

		var result = new[] { new Class { Id = id1 }, new Class { Id = id3 }, new Class { Id = id2 } }
			.AsEnumerable()
			.MinOrOptional(x => x.Id);

		result.Value
			.Should()
			.Be(id1);
	}
}
