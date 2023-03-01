namespace BlazorApp.Data;

class VarietyService
{
    private readonly List<Variety> _varieties = new()
    {
        new(){ Name = "Гала", JamMultiplier = 0.7d },
        new(){ Name = "Голден", JamMultiplier = 0.5d }
    };

    public Variety GetByName(string varietyName)
    {
        if (string.IsNullOrWhiteSpace(varietyName))
            throw new Exception("Не задан сорт яблок");

        var result = _varieties.FirstOrDefault(v => v.Name.Equals(varietyName));

        return result ?? throw new Exception($"Не найден сорт: {varietyName}");
    }

    public void AddNewVariety(string name, double multiplier)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"\"{nameof(name)}\" не может быть пустым или содержать только пробел.", nameof(name));
        }

        if (multiplier == 0)
            throw new ArgumentException("Множитель варенья не может быть 0!");

        _varieties.Add(new Variety()
        {
            JamMultiplier = multiplier,
            Name = name
        });
    }
}
