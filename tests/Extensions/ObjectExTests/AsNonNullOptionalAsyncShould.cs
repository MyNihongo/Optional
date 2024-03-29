﻿// ReSharper disable ExpressionIsAlwaysNull
namespace MyNihongo.Option.Tests.Extensions.ObjectExTests;

public sealed class AsNonNullOptionalAsyncShould
{
#if !NET40
	[Fact]
	public async Task CreateSyncIfNotNull()
	{
		var input = new Class();

		var result = await input.AsNonNullOptionalAsync();

		result.HasValue
			.Should()
			.BeTrue();

		result.Value
			.Should()
			.Be(input);
	}

	[Fact]
	public async Task NotCreateSyncIfNull()
	{
		Class input = null;

		var result = await input.AsNonNullOptionalAsync();

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public async Task CreateValueTaskIfNotNull()
	{
		var input= new Class();
		var inputTask = new ValueTask<Class>(input);

		var result = await inputTask.AsNonNullOptionalAsync();

		result.HasValue
			.Should()
			.BeTrue();

		result.Value
			.Should()
			.Be(input);
	}

	[Fact]
	public async Task NotCreateValueTaskIfNull()
	{
		var input = new ValueTask<Class>((Class)null);

		var result = await input.AsNonNullOptionalAsync();

		result.HasValue
			.Should()
			.BeFalse();
	}

	[Fact]
	public async Task CreateTaskIfNotNull()
	{
		var input = new Class();
		var inputTask = Task.FromResult(input);

		var result = await inputTask.AsNonNullOptionalAsync();

		result.HasValue
			.Should()
			.BeTrue();

		result.Value
			.Should()
			.Be(input);
	}

	[Fact]
	public async Task NotCreateTakIfNull()
	{
		var input = Task.FromResult<Class>(null);

		var result = await input.AsNonNullOptionalAsync();

		result.HasValue
			.Should()
			.BeFalse();
	}
#endif
}
