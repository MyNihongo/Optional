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
		
		public static T? ValueOrDefault<T>(this Optional<T> @this) =>
			@this.HasValue
				? @this.Value
				: default;
		
		public static T ValueOr<T>(this Optional<T> @this, Func<T>? valueFunc)
		{
			if (valueFunc == null)
				throw new ArgumentNullException(nameof(valueFunc));

			return @this.HasValue
				? @this.Value
				: valueFunc();
		}

		public static Optional<TResult> Convert<TSource, TResult>(this Optional<TSource> @this, Func<TSource, TResult> convertFunc) =>
			@this.HasValue
				? convertFunc(@this.Value)
				: Optional<TResult>.None();

		public static TResult ConvertOr<TSource, TResult>(this Optional<TSource> @this, Func<TSource, TResult> convertFunc, TResult fallbackValue) =>
			@this.HasValue
				? convertFunc(@this.Value)
				: fallbackValue;
		
		public static Optional<T> Where<T>(this Optional<T> @this, Func<T, bool>? predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			if (!@this.HasValue)
				return @this;

			return predicate(@this.Value)
				? @this
				: Optional<T>.None();
		}

		public static Optional<T> WhereNot<T>(this Optional<T> @this, Func<T, bool>? predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			if (!@this.HasValue)
				return @this;

			return predicate(@this.Value)
				? Optional<T>.None()
				: @this;
		}

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
		
		public static Optional<T> OrElse<T>(this Optional<T> @this, Func<Optional<T>>? elseFunc)
		{
			if (elseFunc == null)
				throw new ArgumentNullException(nameof(elseFunc));

			return @this.HasValue
				? @this
				: elseFunc();
		}
	}
}
