namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests;

public sealed class ConvertShould
{
	[Fact]
	public void ConvertOptional()
	{
		const int id = 123;

		var result = Optional<Class>.Of(new Class { Id = id })
			.Convert(x => x.Id);

		result.Value
			.Should()
			.Be(id);
	}

	[Fact]
	public void ConvertWithNone()
	{
		var result = Optional<Class>.None()
			.Convert(x => x.Id);

		result.HasValue
			.Should()
			.BeFalse();
	}
}
