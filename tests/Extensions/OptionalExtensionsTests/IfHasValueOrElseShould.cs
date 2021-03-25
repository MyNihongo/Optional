using System.Threading.Tasks;
using FluentAssertions;
using MyNihongo.Option.Extensions;
using Xunit;

namespace MyNihongo.Option.Tests.Extensions.OptionalExtensionsTests
{
	public sealed class IfHasValueOrElseShould
	{
		[Fact]
		public void InvokeSyncSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			id.AsOptional()
				.IfHasValue(x => newId = x)
				.OrElse(() => newId = anotherId);

			newId
				.Should()
				.Be(id);
		}

		[Fact]
		public void NotInvokeSyncSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			Optional<int>.None()
				.IfHasValue(x => newId = x)
				.OrElse(() => newId = anotherId);

			newId
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeSyncTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await id.AsOptional()
				.IfHasValue(x => newId = x)
				.OrElseAsync(() =>
				{
					newId = anotherId;
					return Task.CompletedTask;
				});

			newId
				.Should()
				.Be(id);
		}

		[Fact]
		public async Task NotInvokeSyncTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await Optional<int>.None()
				.IfHasValue(x => newId = x)
				.OrElseAsync(() =>
				{
					newId = anotherId;
					return Task.CompletedTask;
				});

			newId
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeSyncValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await id.AsOptional()
				.IfHasValue(x => newId = x)
				.OrElseAsync(() =>
				{
					newId = anotherId;
					return new ValueTask();
				});

			newId
				.Should()
				.Be(id);
		}

		[Fact]
		public async Task NotInvokeSyncValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await Optional<int>.None()
				.IfHasValue(x => newId = x)
				.OrElseAsync(() =>
				{
					newId = anotherId;
					return new ValueTask();
				});

			newId
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeTaskSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return Task.CompletedTask;
				}).OrElseAsync(() => newId = anotherId);

			newId
				.Should()
				.Be(id);
		}

		[Fact]
		public async Task NotInvokeTaskSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return Task.CompletedTask;
				}).OrElseAsync(() => newId = anotherId);

			newId
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeTaskTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return Task.CompletedTask;
				}).OrElseAsync(() =>
				{
					newId = anotherId;
					return Task.CompletedTask;
				});

			newId
				.Should()
				.Be(id);
		}

		[Fact]
		public async Task NotInvokeTaskTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return Task.CompletedTask;
				}).OrElseAsync(() =>
				{
					newId = anotherId;
					return Task.CompletedTask;
				});

			newId
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeTaskValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return Task.CompletedTask;
				}).OrElseAsync(() =>
				{
					newId = anotherId;
					return new ValueTask();
				});

			newId
				.Should()
				.Be(id);
		}

		[Fact]
		public async Task NotInvokeTaskValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return Task.CompletedTask;
				}).OrElseAsync(() =>
				{
					newId = anotherId;
					return new ValueTask();
				});

			newId
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeValueTaskSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return new ValueTask();
				}).OrElseAsync(() => newId = anotherId);

			newId
				.Should()
				.Be(id);
		}

		[Fact]
		public async Task NotInvokeValueTaskSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return new ValueTask();
				}).OrElseAsync(() => newId = anotherId);

			newId
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeValueTaskTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return new ValueTask();
				}).OrElseAsync(() =>
				{
					newId = anotherId;
					return Task.CompletedTask;
				});

			newId
				.Should()
				.Be(id);
		}

		[Fact]
		public async Task NotInvokeValueTaskTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return new ValueTask();
				}).OrElseAsync(() =>
				{
					newId = anotherId;
					return Task.CompletedTask;
				});

			newId
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeValueTaskValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return new ValueTask();
				}).OrElseAsync(() =>
				{
					newId = anotherId;
					return new ValueTask();
				});

			newId
				.Should()
				.Be(id);
		}

		[Fact]
		public async Task NotInvokeValueTaskValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newId = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newId = x;
					return new ValueTask();
				}).OrElseAsync(() =>
				{
					newId = anotherId;
					return new ValueTask();
				});

			newId
				.Should()
				.Be(anotherId);
		}
	}
}
