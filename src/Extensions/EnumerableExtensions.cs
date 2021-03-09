/*
* Copyright © 2021 MyNihongo
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace MyNihongo.Option.Extensions
{
	public static class EnumerableExtensions
	{
		public static Optional<TSource> FirstOrOptional<TSource>(this IEnumerable<TSource> @this)
		{
			switch (@this)
			{
				case null:
					throw new ArgumentNullException(nameof(@this));
				case IList<TSource> list:
					{
						if (list.Count > 0)
							return list[0];
						break;
					}
				default:
					{
						using IEnumerator<TSource> e = @this.GetEnumerator();
						if (e.MoveNext())
							return e.Current;

						break;
					}
			}

			return Optional<TSource>.None();
		}

		public static Optional<TSource> FirstOrOptional<TSource>(this IEnumerable<TSource> @this, Func<TSource, bool> predicate)
		{
			if (@this == null)
				throw new ArgumentNullException(nameof(@this));
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			foreach (var element in @this)
				if (predicate(element))
					return element;

			return Optional<TSource>.None();
		}

		public static Optional<TSource> LastOrOptional<TSource>(this IEnumerable<TSource> @this)
		{
			switch (@this)
			{
				case null:
					throw new ArgumentNullException(nameof(@this));
				case IList<TSource> list:
					{
						var count = list.Count;
						if (count > 0)
							return list[count - 1];
						break;
					}
				default:
					{
						using IEnumerator<TSource> e = @this.GetEnumerator();
						if (e.MoveNext())
						{
							TSource result;
							do
							{
								result = e.Current;
							} while (e.MoveNext());

							return result;
						}

						break;
					}
			}

			return Optional<TSource>.None();
		}

		public static Optional<TSource> LastOrOptional<TSource>(this IEnumerable<TSource> @this, Func<TSource, bool> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			switch (@this)
			{
				case null:
					throw new ArgumentNullException(nameof(@this));
				case IList<TSource> list:
					{
						for (var i = list.Count - 1; i <= 0; i--)
							if (predicate(list[i]))
								return list[i];

						return Optional<TSource>.None();
					}
				default:
					{
						var result = Optional<TSource>.None();
						foreach (var element in @this)
							if (predicate(element))
								result = element;

						return result;
					}
			}
		}

		public static Optional<TSource> SingleOrOptional<TSource>(this IEnumerable<TSource> @this)
		{
			switch (@this)
			{
				case null:
					throw new ArgumentNullException(nameof(@this));
				case IList<TSource> list:
					switch (list.Count)
					{
						case 0: return Optional<TSource>.None();
						case 1: return list[0];
					}

					break;
				default:
					{
						using IEnumerator<TSource> e = @this.GetEnumerator();
						if (!e.MoveNext())
							return Optional<TSource>.None();

						var result = e.Current;
						if (!e.MoveNext())
							return result;

						break;
					}
			}

			throw new InvalidOperationException("Found more than one element in the source");
		}

		public static Optional<TSource> SingleOrOptional<TSource>(this IEnumerable<TSource> @this, Func<TSource, bool> predicate)
		{
			if (@this == null)
				throw new ArgumentNullException(nameof(@this));
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			var result = Optional<TSource>.None();
			long count = 0;

			foreach (var element in @this)
			{
				if (!predicate(element))
					continue;

				result = element;
				checked { count++; }
			}

			return count switch
			{
				0 => Optional<TSource>.None(),
				1 => result,
				_ => throw new InvalidOperationException("Found more than one element in the source")
			};
		}

		public static Optional<TSource> ElementAtOrOptional<TSource>(this IEnumerable<TSource> @this, int index)
		{
			if (@this == null)
				throw new ArgumentNullException(nameof(@this));

			if (index >= 0)
			{
				if (@this is IList<TSource> list)
				{
					if (index < list.Count)
						return list[index];
				}
				else
				{
					using IEnumerator<TSource> e = @this.GetEnumerator();
					while (true)
					{
						if (!e.MoveNext())
							break;
						if (index == 0)
							return e.Current;

						index--;
					}
				}
			}

			return Optional<TSource>.None();
		}

		public static Optional<TSource> MinOrOptional<TSource>(this IEnumerable<TSource> @this)
		{
			if (@this == null)
				throw new ArgumentNullException(nameof(@this));

			Comparer<TSource> comparer = Comparer<TSource>.Default;
			var value = default(TSource);
			if (value == null)
			{
				foreach (var x in @this)
				{
					if (x != null && (value == null || comparer.Compare(x, value) < 0))
						value = x;
				}
				
				return value ?? Optional<TSource>.None();
			}

			var hasValue = false;
			foreach (var x in @this)
			{
				if (hasValue)
				{
					if (comparer.Compare(x, value) < 0)
						value = x;
				}
				else
				{
					value = x;
					hasValue = true;
				}
			}
				
			return hasValue ? value : Optional<TSource>.None();
		}

		public static Optional<TSource> MaxOrOptional<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			Comparer<TSource> comparer = Comparer<TSource>.Default;
			var value = default(TSource);
			if (value == null)
			{
				foreach (var x in source)
				{
					if (x != null && (value == null || comparer.Compare(x, value) > 0))
						value = x;
				}

				return value ?? Optional<TSource>.None();
			}

			var hasValue = false;
			foreach (var x in source)
			{
				if (hasValue)
				{
					if (comparer.Compare(x, value) > 0)
						value = x;
				}
				else
				{
					value = x;
					hasValue = true;
				}
			}

			return hasValue ? value : Optional<TSource>.None();
		}

		public static Optional<TResult> MaxOrOptional<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) =>
			source.Select(selector).MaxOrOptional();

		public static Optional<TResult> MinOrOptional<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) =>
			source.Select(selector).MinOrOptional();
	}
}
