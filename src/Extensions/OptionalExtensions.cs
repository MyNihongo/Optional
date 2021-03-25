/*
* Copyright © 2021 MyNihongo
*/

using System;
using System.Threading.Tasks;

namespace MyNihongo.Option.Extensions
{
	public static class OptionalExtensions
	{
		public static T ValueOr<T>(this Optional<T> @this, T fallbackValue) =>
			@this.HasValue
				? @this.Value
				: fallbackValue;

		public static Optional<TResult> Convert<TSource, TResult>(this Optional<TSource> @this, Func<TSource, TResult> convertFunc) =>
			@this.HasValue
				? convertFunc(@this.Value)
				: Optional<TResult>.None();

		public static TResult ConvertOr<TSource, TResult>(this Optional<TSource> @this, Func<TSource, TResult> convertFunc, TResult fallbackValue) =>
			@this.HasValue
				? convertFunc(@this.Value)
				: fallbackValue;

		public static OptionalElse IfHasValue<T>(this Optional<T> @this, Action<T>? action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			if (!@this.HasValue)
				return OptionalElse.Execute();

			action(@this.Value);
			return OptionalElse.Finished();
		}

		public static async ValueTask<OptionalElse> IfHasValueAsync<T>(this Optional<T> @this, Func<T, Task>? actionAsync)
		{
			if (actionAsync == null)
				throw new ArgumentNullException(nameof(actionAsync));

			if (!@this.HasValue)
				return OptionalElse.Execute();

			await actionAsync(@this.Value)
				.ConfigureAwait(false);

			return OptionalElse.Finished();
		}

		public static async ValueTask<OptionalElse> IfHasValueAsync<T>(this Optional<T> @this, Func<T, ValueTask>? actionAsync)
		{
			if (actionAsync == null)
				throw new ArgumentNullException(nameof(actionAsync));

			if (!@this.HasValue)
				return OptionalElse.Execute();

			await actionAsync(@this.Value)
				.ConfigureAwait(false);

			return OptionalElse.Finished();
		}
	}
}
