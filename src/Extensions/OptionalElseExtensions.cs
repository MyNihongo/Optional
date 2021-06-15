using System;
using System.Threading.Tasks;

namespace MyNihongo.Option.Extensions
{
	public static class OptionalElseExtensions
	{
		public static void OrElse(this OptionalElse @this, Action? action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			if (@this.ShouldExecute)
				action();
		}
#if NET5_0
		public static async ValueTask OrElseAsync(this OptionalElse @this, Func<Task>? actionAsync)
		{
			if (actionAsync == null)
				throw new ArgumentNullException(nameof(actionAsync));

			if (@this.ShouldExecute)
				await actionAsync()
					.ConfigureAwait(false);
		}

		public static async ValueTask OrElseAsync(this OptionalElse @this, Func<ValueTask>? actionAsync)
		{
			if (actionAsync == null)
				throw new ArgumentNullException(nameof(actionAsync));

			if (@this.ShouldExecute)
				await actionAsync()
					.ConfigureAwait(false);
		}

		public static async ValueTask OrElseAsync(this ValueTask<OptionalElse> @this, Action? action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			var optionalElse = await @this.ConfigureAwait(false);

			if (optionalElse.ShouldExecute)
				action();
		}

		public static async ValueTask OrElseAsync(this ValueTask<OptionalElse> @this, Func<Task>? actionAsync)
		{
			if (actionAsync == null)
				throw new ArgumentNullException(nameof(actionAsync));

			var optionalElse = await @this.ConfigureAwait(false);

			if (optionalElse.ShouldExecute)
				await actionAsync()
					.ConfigureAwait(false);
		}

		public static async ValueTask OrElseAsync(this ValueTask<OptionalElse> @this, Func<ValueTask>? actionAsync)
		{
			if (actionAsync == null)
				throw new ArgumentNullException(nameof(actionAsync));

			var optionalElse = await @this.ConfigureAwait(false);

			if (optionalElse.ShouldExecute)
				await actionAsync()
					.ConfigureAwait(false);
		}
#elif NET40
		public static void OrElse(this OptionalElse @this, Func<Task>? actionAsync)
		{
			if (actionAsync == null)
				throw new ArgumentNullException(nameof(actionAsync));

			if (@this.ShouldExecute)
				Task.WaitAll(actionAsync());
		}

		public static void OrElse(this Task<OptionalElse> @this, Action? action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			Task.WaitAll(@this);
			var optionalElse = @this.Result;

			if (optionalElse.ShouldExecute)
				action();
		}

		public static void OrElseAsync(this Task<OptionalElse> @this, Func<Task>? actionAsync)
		{
			if (actionAsync == null)
				throw new ArgumentNullException(nameof(actionAsync));

			Task.WaitAll(@this);
			var optionalElse = @this.Result;

			if (optionalElse.ShouldExecute)
				Task.WaitAll(actionAsync());
		}
#endif
	}
}
