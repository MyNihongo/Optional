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
			int? newValue = null, fallbackValue = null;

			id.AsOptional()
				.IfHasValue(x => newValue = x)
				.OrElse(() => fallbackValue = anotherId);

			newValue
				.Should()
				.Be(id);

			fallbackValue
				.Should()
				.BeNull();
		}

		[Fact]
		public void NotInvokeSyncSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			Optional<int>.None()
				.IfHasValue(x => newValue = x)
				.OrElse(() => fallbackValue = anotherId);

			newValue
				.Should()
				.BeNull();

			fallbackValue
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeSyncTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await id.AsOptional()
				.IfHasValue(x => newValue = x)
				.OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return Task.CompletedTask;
				});

			newValue
				.Should()
				.Be(id);

			fallbackValue
				.Should()
				.BeNull();
		}

		[Fact]
		public async Task NotInvokeSyncTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await Optional<int>.None()
				.IfHasValue(x => newValue = x)
				.OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return Task.CompletedTask;
				});

			newValue
				.Should()
				.BeNull();

			fallbackValue
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeSyncValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await id.AsOptional()
				.IfHasValue(x => newValue = x)
				.OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return new ValueTask();
				});

			newValue
				.Should()
				.Be(id);

			fallbackValue
				.Should()
				.BeNull();
		}

		[Fact]
		public async Task NotInvokeSyncValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await Optional<int>.None()
				.IfHasValue(x => newValue = x)
				.OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return new ValueTask();
				});

			newValue
				.Should()
				.BeNull();

			fallbackValue
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeTaskSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return Task.CompletedTask;
				}).OrElseAsync(() => fallbackValue = anotherId);

			newValue
				.Should()
				.Be(id);

			fallbackValue
				.Should()
				.BeNull();
		}

		[Fact]
		public async Task NotInvokeTaskSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return Task.CompletedTask;
				}).OrElseAsync(() => fallbackValue = anotherId);

			newValue
				.Should()
				.BeNull();

			fallbackValue
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeTaskTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return Task.CompletedTask;
				}).OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return Task.CompletedTask;
				});

			newValue
				.Should()
				.Be(id);

			fallbackValue
				.Should()
				.BeNull();
		}

		[Fact]
		public async Task NotInvokeTaskTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return Task.CompletedTask;
				}).OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return Task.CompletedTask;
				});

			newValue
				.Should()
				.BeNull();

			fallbackValue
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeTaskValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return Task.CompletedTask;
				}).OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return new ValueTask();
				});

			newValue
				.Should()
				.Be(id);

			fallbackValue
				.Should()
				.BeNull();
		}

		[Fact]
		public async Task NotInvokeTaskValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return Task.CompletedTask;
				}).OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return new ValueTask();
				});

			newValue
				.Should()
				.BeNull();

			fallbackValue
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeValueTaskSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return new ValueTask();
				}).OrElseAsync(() => fallbackValue = anotherId);

			newValue
				.Should()
				.Be(id);

			fallbackValue
				.Should()
				.BeNull();
		}

		[Fact]
		public async Task NotInvokeValueTaskSync()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return new ValueTask();
				}).OrElseAsync(() => fallbackValue = anotherId);

			newValue
				.Should()
				.BeNull();

			fallbackValue
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeValueTaskTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return new ValueTask();
				}).OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return Task.CompletedTask;
				});

			newValue
				.Should()
				.Be(id);

			fallbackValue
				.Should()
				.BeNull();
		}

		[Fact]
		public async Task NotInvokeValueTaskTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return new ValueTask();
				}).OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return Task.CompletedTask;
				});

			newValue
				.Should()
				.BeNull();

			fallbackValue
				.Should()
				.Be(anotherId);
		}

		[Fact]
		public async Task InvokeValueTaskValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await id.AsOptional()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return new ValueTask();
				}).OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return new ValueTask();
				});

			newValue
				.Should()
				.Be(id);

			fallbackValue
				.Should()
				.BeNull();
		}

		[Fact]
		public async Task NotInvokeValueTaskValueTask()
		{
			const int id = 123, anotherId = id * 2;
			int? newValue = null, fallbackValue = null;

			await Optional<int>.None()
				.IfHasValueAsync(x =>
				{
					newValue = x;
					return new ValueTask();
				}).OrElseAsync(() =>
				{
					fallbackValue = anotherId;
					return new ValueTask();
				});

			newValue
				.Should()
				.BeNull();

			fallbackValue
				.Should()
				.Be(anotherId);
		}
	}
}
