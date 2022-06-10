// ReSharper disable ExpressionIsAlwaysNull
namespace MyNihongo.Option.Tests.Extensions.OptionalExTests;

public sealed class IfHasValueAsyncShould
{
#if !NET40
	[Fact]
	public async Task ThrowExceptionIfActionTaskNull()
	{
		Func<Class, Task> actionAsync = null;

		Func<Task> action = async () => await Optional<Class>.Of(new Class())
			.IfHasValueAsync(actionAsync);

		await action
			.Should()
			.ThrowExactlyAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task NotInvokeIfNoValueWithTask()
	{
		int? newId = null;

		var result = await Optional<Class>.None()
			.IfHasValueAsync(x =>
			{
				newId = x.Id;
				return Task.CompletedTask;
			});

		newId
			.Should()
			.BeNull();

		result.ShouldExecute
			.Should()
			.BeTrue();
	}

	[Fact]
	public async Task InvokeIfHasValueWithTask()
	{
		const int id = 123;
		int? newId = null;

		var result = await Optional<Class>.Of(new Class { Id = id })
			.IfHasValueAsync(x =>
			{
				newId = x.Id;
				return Task.CompletedTask;
			});

		newId
			.Should()
			.Be(id);

		result.ShouldExecute
			.Should()
			.BeFalse();
	}

	[Fact]
	public async Task ThrowExceptionIfActionValueTaskNull()
	{
		Func<Class, ValueTask> actionAsync = null;

		Func<Task> action = async () => await Optional<Class>.Of(new Class())
			.IfHasValueAsync(actionAsync);

		await action
			.Should()
			.ThrowExactlyAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task NotInvokeIfNoValueWithValueTask()
	{
		int? newId = null;

		var result = await Optional<Class>.None()
			.IfHasValueAsync(x =>
			{
				newId = x.Id;
				return new ValueTask();
			});

		newId
			.Should()
			.BeNull();

		result.ShouldExecute
			.Should()
			.BeTrue();
	}

	[Fact]
	public async Task InvokeIfHasValueWithValueTask()
	{
		const int id = 123;
		int? newId = null;

		var result = await Optional<Class>.Of(new Class { Id = id })
			.IfHasValueAsync(x =>
			{
				newId = x.Id;
				return new ValueTask();
			});

		newId
			.Should()
			.Be(id);

		result.ShouldExecute
			.Should()
			.BeFalse();
	}

	[Fact]
	public async Task ThrowExceptionIfActionNull()
	{
		Func<Task> action = async () => await ValueTask
			.FromResult(Optional<int>.None())
			.IfHasValueAsync(null);

		await action
			.Should()
			.ThrowExactlyAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task NotInvokeActionIfNoValue()
	{
		int? newId = null;

		var result = await ValueTask.FromResult(Optional<int>.None())
			.IfHasValueAsync(x => newId = x);

		newId
			.Should()
			.BeNull();

		result.ShouldExecute
			.Should()
			.BeTrue();
	}

	[Fact]
	public async Task InvokeActionIfHasValue()
	{
		const int id = 123;
		int? newId = null;

		var result = await ValueTask.FromResult(Optional<int>.Of(id))
			.IfHasValueAsync(x => newId = x);

		newId
			.Should()
			.Be(id);

		result.ShouldExecute
			.Should()
			.BeFalse();
	}
#endif
}
