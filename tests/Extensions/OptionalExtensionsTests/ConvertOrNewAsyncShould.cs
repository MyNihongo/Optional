using System;
using System.Threading.Tasks;
using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;
// ReSharper disable ExpressionIsAlwaysNull

namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests
{
#if NET5_0
	public sealed class ConvertOrNewAsyncShould
	{
		[Fact]
		public async Task ThrowExceptionIfFuncNull()
		{
			Func<int, Class> convertFunc = null;

			Func<Task> actionAsync = async () => await Task.FromResult(Optional<int>.None())
				.ConvertOrNewAsync(convertFunc);

			await actionAsync
				.Should()
				.ThrowExactlyAsync<ArgumentNullException>();
		}

		[Fact]
		public async Task ConvertObjectIfHasValue()
		{
			const int id = 123;

			var expectedResult = new Class
			{
				Id = id
			};

			var result = await Task.FromResult(Optional<int>.Of(id))
				.ConvertOrNewAsync(x => new Class { Id = x });

			result
				.Should()
				.BeEquivalentTo(expectedResult);
		}

		[Fact]
		public async Task CreateNewObjectIfNoValue()
		{
			var expectedResult = new Class();

			var result = await Task.FromResult(Optional<int>.None())
				.ConvertOrNewAsync(x => new Class { Id = x });

			result
				.Should()
				.BeEquivalentTo(expectedResult);
		}
	}
#endif
}
