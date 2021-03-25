using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;

namespace MyNihongo.Option.Tests.Extensions.ObjectExtensionsTests
{
	public sealed class AsOptionalShould
	{
		[Theory]
		[InlineData(null)]
		[InlineData(true)]
		[InlineData(123)]
		[InlineData("string")]
		[InlineData(123L)]
		[InlineData(123d)]
		public void CreateOptional(object input)
		{
			var result = input.AsOptional();

			result.HasValue
				.Should()
				.BeTrue();

			result.Value
				.Should()
				.Be(input);
		}
	}
}
