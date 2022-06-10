// ReSharper disable ExpressionIsAlwaysNull
namespace MyNihongo.Option.Tests.Extensions.OptionalExTests;

public sealed class OrElseShould
{
	[Fact]
	public void ThrowExceptionIfNull()
	{
		Func<Optional<Class>> func = null;

		Action action = () => Optional<Class>.None()
			.OrElse(func);

		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void ReturnValueIfPresent()
	{
		var counter = 0;
		var input = new Class();

		var result = input.AsOptional()
			.OrElse(() =>
			{
				counter++;
				return Optional<Class>.None();
			});

		result.Value
			.Should()
			.Be(input);

		counter
			.Should()
			.Be(0);
	}

	[Fact]
	public void ReturnFallbackValue()
	{
		var counter = 0;
		var input = new Class();

		var result = Optional<Class>.None()
			.OrElse(() =>
			{
				counter++;
				return input;
			});

		result.Value
			.Should()
			.Be(input);

		counter
			.Should()
			.Be(1);
	}

	[Fact]
	public void NotInvokeAfterValueFound()
	{
		var counter = 0;
		var input = new Class();

		var result = Optional<Class>.None()
			.OrElse(() =>
			{
				counter++;
				return Optional<Class>.None();
			})
			.OrElse(() =>
			{
				counter++;
				return input;
			})
			.OrElse(() =>
			{
				counter++;
				return Optional<Class>.None();
			});

		result.Value
			.Should()
			.Be(input);

		counter
			.Should()
			.Be(2);
	}

	[Fact]
	public void ReturnNoneIfNoValue()
	{
		var counter = 0;

		var result = Optional<Class>.None()
			.OrElse(() =>
			{
				counter++;
				return Optional<Class>.None();
			})
			.OrElse(() =>
			{
				counter++;
				return Optional<Class>.None();
			})
			.OrElse(() =>
			{
				counter++;
				return Optional<Class>.None();
			});

		result.HasValue
			.Should()
			.BeFalse();

		counter
			.Should()
			.Be(3);
	}
}
