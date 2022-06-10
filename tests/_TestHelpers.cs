namespace MyNihongo.Option.Tests;

internal static class TestHelpers
{
	public static void ShouldThrow<T>(this Action action)
		where T : Exception
	{
#if NET40
		action.ShouldThrowExactly<T>();
#else
		action
			.Should()
			.ThrowExactly<T>();
#endif
	}
}

internal static class Arrays
{
#if NET40
	private static class EmptyArray<T>
	{
#pragma warning disable CA1825 // this is the implementation of Array.Empty<T>()
		internal static readonly T[] Value = new T[0];
#pragma warning restore CA1825
	}
#endif

	public static T[] Empty<T>()
	{
#if NET40
		return EmptyArray<T>.Value;
#else
		return Array.Empty<T>();
#endif
	}
}
