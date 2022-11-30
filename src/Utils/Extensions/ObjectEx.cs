namespace MyNihongo.Option;

public static class ObjectEx
{
	public static Optional<T> AsOptional<T>(this T @this) =>
		Optional<T>.Of(@this);

	public static Optional<T> AsNonNullOptional<T>(this T @this) =>
		@this != null
			? Optional<T>.Of(@this)
			: Optional<T>.None();

#if !NET40
	public static ValueTask<Optional<T>> AsOptionalAsync<T>(this T @this) =>
		new(Optional<T>.Of(@this));

	public static async ValueTask<Optional<T>> AsOptionalAsync<T>(this ValueTask<T> @this) =>
		await @this.ConfigureAwait(false);

	public static async ValueTask<Optional<T>> AsOptionalAsync<T>(this Task<T> @this) =>
		await @this.ConfigureAwait(false);

	public static ValueTask<Optional<T>> AsNonNullOptionalAsync<T>(this T @this)
	{
		var result = @this != null
			? Optional<T>.Of(@this)
			: Optional<T>.None();

		return new ValueTask<Optional<T>>(result);
	}

	public static async ValueTask<Optional<T>> AsNonNullOptionalAsync<T>(this ValueTask<T> @this)
	{
		var result = await @this.ConfigureAwait(false);

		return result != null
			? Optional<T>.Of(result)
			: Optional<T>.None();
	}

	public static async ValueTask<Optional<T>> AsNonNullOptionalAsync<T>(this Task<T> @this)
	{
		var result = await @this.ConfigureAwait(false);

		return result != null
			? Optional<T>.Of(result)
			: Optional<T>.None();
	}
#endif
}
