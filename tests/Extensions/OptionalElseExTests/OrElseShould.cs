namespace MyNihongo.Option.Tests.Extensions.OptionalElseExTests;

public sealed class OrElseShould
{
	[Fact]
	public void ThrowExceptionIfActionNull()
	{
		var action = () => OptionalElse.Execute()
			.OrElse(null);

		action.ShouldThrow<ArgumentNullException>();
	}

	[Fact]
	public void ExecuteAction()
	{
		const int id = 123;
		int? newId = null;

		OptionalElse.Execute()
			.OrElse(() => newId = id);

		newId
			.Should()
			.Be(id);
	}

	[Fact]
	public void NotExecuteAction()
	{
		const int id = 123;
		int? newId = null;

		OptionalElse.Finished()
			.OrElse(() => newId = id);

		newId
			.Should()
			.BeNull();
	}
}
