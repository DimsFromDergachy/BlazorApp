namespace BlazorApp.Data;

public sealed record Variety
{
    public string Name { get; init; }
    public decimal JamMultiplier { get; init; }
}