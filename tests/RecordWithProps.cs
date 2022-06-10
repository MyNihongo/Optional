namespace MyNihongo.Option.Tests;

public sealed record RecordWithProps
{
	public int Id { get; set; }

	public Optional<string> Name { get; set; }

	public Optional<decimal> Salary { get; set; }

	public Optional<bool> IsMarried { get; set; }
}
