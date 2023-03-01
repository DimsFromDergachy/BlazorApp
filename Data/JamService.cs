using BlazorApp.Data;

public class JamService
{
    public double GetJamVolume(Bucket[] buckets, Variety variety = null)
    {
        Func<Bucket, bool> condition = variety == null
        ? b => true
        : b => b.Variety == variety.Name;

        Func<Bucket, double> sum = variety == null
        ? b => b.Weight
        : b => b.Weight * variety.JamMultiplier;

        var result = buckets.Where(condition).Sum(sum);

        return result;
    }

    public int GetJarsCounts(double volume)
    {
        return (int) Math.Round(volume, 0, MidpointRounding.ToPositiveInfinity);
    }
}