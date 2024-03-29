// ReSharper disable ExpressionIsAlwaysNull
namespace MyNihongo.Option.Tests.Extensions.OptionalExTests;

public sealed class ValueOrShould
{
	[Fact]
	public void ReturnValue()
	{
		const int value = 123, anotherValue = value * 2;

		var result = Optional<int>.Of(value)
			.ValueOr(anotherValue);

		result
			.Should()
			.Be(value);
	}

	[Fact]
	public void ReturnFallbackValue()
	{
		const int value = 123, anotherValue = value * 2;

		var result = Optional<int>.None()
			.ValueOr(anotherValue);

		result
			.Should()
			.Be(anotherValue);
	}

	[Fact]
	public void ThrowExceptionIfNull()
	{
		Func<Class> input = null;

		Action action = () => Optional<Class>.None()
			.ValueOr(input);

		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void ReturnValueIfPresent()
	{
		Class item1 = new() { Id = 1 }, item2 = new() { Id = 2 };

		var result = item1.AsOptional()
			.ValueOr(() => item2);

		result
			.Should()
			.Be(item1);
	}

	[Fact]
	public void ReturnFuncValueIfNotPresent()
	{
		Class item2 = new() { Id = 2 };

		var result = Optional<Class>.None()
			.ValueOr(() => item2);

		result
			.Should()
			.Be(item2);
	}
}
