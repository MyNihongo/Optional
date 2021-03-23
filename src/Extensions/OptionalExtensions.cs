/*
* Copyright © 2021 MyNihongo
*/

using System;

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

		public static void IfHasValue<T>(this Optional<T> @this, Action<T>? action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			if (@this.HasValue)
				action(@this.Value);
		}
		
		public static async ValueTask IfHasValueAsync<T>(this Optional<T> @this, Func<T, Task>? funcAsync)
		{
			if (funcAsync == null)
				throw new ArgumentNullException(nameof(funcAsync));

			if (@this.HasValue)
				await funcAsync(@this.Value)
					.ConfigureAwait(false);
		}

		public static async ValueTask IfHasValueAsync<T>(this Optional<T> @this, Func<T, ValueTask>? funcAsync)
		{
			if (funcAsync == null)
				throw new ArgumentNullException(nameof(funcAsync));

			if (@this.HasValue)
				await funcAsync(@this.Value)
					.ConfigureAwait(false);
		}
	}
}
