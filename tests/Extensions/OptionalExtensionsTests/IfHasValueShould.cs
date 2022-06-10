namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests;

public sealed class IfHasValueShould
{
	[Fact]
	public void ThrowExceptionIfActionNull()
	{
		Action action = () => Optional<Class>.Of(new Class())
			.IfHasValue(null);

		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void NotInvokeIfNoValue()
	{
		int? newId = null;

		var result = Optional<Class>.None()
			.IfHasValue(x => newId = x.Id);

		newId
			.Should()
			.BeNull();

		result.ShouldExecute
			.Should()
			.BeTrue();
	}

	[Fact]
	public void InvokeIfHasValue()
	{
		const int id = 123;
		int? newId = null;

		var result = Optional<Class>.Of(new Class { Id = id })
			.IfHasValue(x => newId = x.Id);

		newId
			.Should()
			.Be(id);

		result.ShouldExecute
			.Should()
			.BeFalse();
	}
}
