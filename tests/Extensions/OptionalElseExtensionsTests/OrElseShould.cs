using System;
using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;

namespace MyNihongo.Option.Tests.Extensions.OptionalElseExtensionsTests
{
	public sealed class OrElseShould
	{
		[Fact]
		public void ThrowExceptionIfActionNull()
		{
			Action action = () => OptionalElse.Execute()
				.OrElse(null);

#if NET5_0
			action
				.Should()
				.ThrowExactly<ArgumentNullException>();
#elif NET40
			action
				.ShouldThrowExactly<ArgumentNullException>();
#endif
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
}
