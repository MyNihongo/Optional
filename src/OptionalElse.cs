namespace MyNihongo.Option;

public readonly struct OptionalElse
{
	private OptionalElse(bool shouldExecute)
	{
		ShouldExecute = shouldExecute;
	}

	internal bool ShouldExecute { get; }

	internal static OptionalElse Execute() =>
		new(true);

	internal static OptionalElse Finished() =>
		new(false);
}
