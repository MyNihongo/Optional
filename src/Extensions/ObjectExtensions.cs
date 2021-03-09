/*
* Copyright © 2021 MyNihongo
*/

using System.Threading.Tasks;

namespace MyNihongo.Option.Extensions
{
	public static class ObjectExtensions
	{
		public static Optional<T> AsOptional<T>(this T @this) =>
			Optional<T>.Of(@this);

		public static async ValueTask<Optional<T>> AsOptionalAsync<T>(this ValueTask<T> @this) =>
			await @this.ConfigureAwait(false);

		public static async Task<Optional<T>> AsOptionalAsync<T>(this Task<T> @this) =>
			await @this.ConfigureAwait(false);
	}
}
