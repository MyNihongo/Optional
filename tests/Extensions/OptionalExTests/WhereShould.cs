// ReSharper disable ExpressionIsAlwaysNull
namespace MyNihongo.Option.Tests.Extensions.OptionalExTests;

public sealed class WhereShould
{
	[Fact]
	public void ThrowExceptionIfNull()
	{
		Func<Class, bool> func = null;

		Action action = () => Optional<Class>.None()
			.Where(func);

		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void ReturnNoneIfNoValue()
	{
		var result = Optional<Class>.None()
			.Where(x => x.Id == 0);

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnNoneIfPredicateFalse()
	{
		const int id = 1;
		var input = new Class { Id = id };

		var result = input.AsOptional()
			.Where(x => x.Id != id);

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public void ReturnValueIfPredicateTrue()
	{
		const int id = 1;
		var input = new Class { Id = id };

		var result = input.AsOptional()
			.Where(x => x.Id == id);

		result.Value
			.Should()
			.Be(input);
	}
}
