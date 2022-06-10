// ReSharper disable ExpressionIsAlwaysNull
namespace MyNihongo.Option.Tests.Extensions.OptionalElseExtensionsTests;

public sealed class OrElseAsyncShould
{
#if !NET40
	[Fact]
	public async Task ThrowExceptionForStandardIfTaskNull()
	{
		Func<Task> execute = null;

		var action = async () => await OptionalElse.Execute()
			.OrElseAsync(execute);

		await action
			.Should()
			.ThrowExactlyAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task ExecuteActionTaskForStandard()
	{
		const int id = 123;
		int? newId = null;

		await OptionalElse.Execute()
			.OrElseAsync(() =>
			{
				newId = id;
				return Task.CompletedTask;
			});

		newId
			.Should()
			.Be(id);
	}

	[Fact]
	public async Task NotExecuteActionTaskForStandard()
	{
		const int id = 123;
		int? newId = null;

		await OptionalElse.Finished()
			.OrElseAsync(() =>
			{
				newId = id;
				return Task.CompletedTask;
			});

		newId
			.Should()
			.BeNull();
	}

	[Fact]
	public async Task ThrowExceptionForStandardIfValueTaskNull()
	{
		Func<ValueTask> execute = null;

		var action = async () => await OptionalElse.Execute()
			.OrElseAsync(execute);

		await action
			.Should()
			.ThrowExactlyAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task ExecuteActionValueTaskForStandard()
	{
		const int id = 123;
		int? newId = null;

		await OptionalElse.Execute()
			.OrElseAsync(() =>
			{
				newId = id;
				return new ValueTask();
			});

		newId
			.Should()
			.Be(id);
	}

	[Fact]
	public async Task NotExecuteActionValueTaskForStandard()
	{
		const int id = 123;
		int? newId = null;

		await OptionalElse.Finished()
			.OrElseAsync(() =>
			{
				newId = id;
				return new ValueTask();
			});

		newId
			.Should()
			.BeNull();
	}

	[Fact]
	public async Task ThrowExceptionIfActionNull()
	{
		Action execute = null;

		var action = async () => await new ValueTask<OptionalElse>(OptionalElse.Execute())
			.OrElseAsync(execute);

		await action
			.Should()
			.ThrowExactlyAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task ExecuteAction()
	{
		const int id = 123;
		int? newId = null;

		await new ValueTask<OptionalElse>(OptionalElse.Execute())
			.OrElseAsync(() => newId = id);

		newId
			.Should()
			.Be(id);
	}

	[Fact]
	public async Task NotExecuteAction()
	{
		const int id = 123;
		int? newId = null;

		await new ValueTask<OptionalElse>(OptionalElse.Finished())
			.OrElseAsync(() => newId = id);

		newId
			.Should()
			.BeNull();
	}

	[Fact]
	public async Task ThrowExceptionIfTaskNull()
	{
		Func<Task> execute = null;

		var action = async () => await new ValueTask<OptionalElse>(OptionalElse.Execute())
			.OrElseAsync(execute);

		await action
			.Should()
			.ThrowExactlyAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task ExecuteActionTask()
	{
		const int id = 123;
		int? newId = null;

		await new ValueTask<OptionalElse>(OptionalElse.Execute())
			.OrElseAsync(() =>
			{
				newId = id;
				return Task.CompletedTask;
			});

		newId
			.Should()
			.Be(id);
	}

	[Fact]
	public async Task NotExecuteActionTask()
	{
		const int id = 123;
		int? newId = null;

		await new ValueTask<OptionalElse>(OptionalElse.Finished())
			.OrElseAsync(() =>
			{
				newId = id;
				return Task.CompletedTask;
			});

		newId
			.Should()
			.BeNull();
	}

	[Fact]
	public async Task ThrowExceptionIfValueTaskNull()
	{
		Func<ValueTask> execute = null;

		var action = async () => await new ValueTask<OptionalElse>(OptionalElse.Execute())
			.OrElseAsync(execute);

		await action
			.Should()
			.ThrowExactlyAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task ExecuteActionValueTask()
	{
		const int id = 123;
		int? newId = null;

		await new ValueTask<OptionalElse>(OptionalElse.Execute())
			.OrElseAsync(() =>
			{
				newId = id;
				return new ValueTask();
			});

		newId
			.Should()
			.Be(id);
	}

	[Fact]
	public async Task NotExecuteActionValueTask()
	{
		const int id = 123;
		int? newId = null;

		await new ValueTask<OptionalElse>(OptionalElse.Finished())
			.OrElseAsync(() =>
			{
				newId = id;
				return new ValueTask();
			});

		newId
			.Should()
			.BeNull();
	}
#endif
}