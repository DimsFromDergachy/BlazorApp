namespace BlazorApp.Data;

public class BasementService
{
    private IList<Bucket> _buckets = new List<Bucket>();

    public void Add(Bucket bucket)
    {
        _buckets.Add(bucket);
    }

    public Result GetResult(string variety = null)
    {
        if (string.IsNullOrEmpty(variety))
        {
            return new Result
            {
                 AppleAmount = _buckets.Sum(b => b.Amount),
                 BucketAmount = _buckets.Count(),
                 Weight = _buckets.Sum(b => b.Weight),
                 AverageWeight = _buckets.Sum(b => b.Weight) / _buckets.Sum(b => b.Amount),
            };
        }

        return new Result
        {
                AppleAmount = _buckets.Where(b => b.Variety.Equals(variety)).Sum(b => b.Amount),
                BucketAmount = _buckets.Where(b => b.Variety.Equals(variety)).Count(),
                Weight = _buckets.Where(b => b.Variety.Equals(variety)).Sum(b => b.Weight),
                AverageWeight = _buckets.Where(b => b.Variety.Equals(variety)).Sum(b => b.Weight) / _buckets.Sum(b => b.Amount),
        };
    }
}

public struct Result
{
    public int AppleAmount { get; init; }
    public int BucketAmount { get; init; }
    public double Weight { get; init; }
    public double AverageWeight { get; init; }
}