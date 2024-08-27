
using System;

// AnimalManager.cs
public class AnimalManager
{
    public int AnimalCount { get; private set; } = 0;
    public event Action<int> OnAnimalCountChanged;

    public void AddAnimals(int amount)
    {
        AnimalCount += amount;
        OnAnimalCountChanged?.Invoke(AnimalCount);
    }
}
// HeartManager.cs
public class HeartManager
{
    public int Hearts { get; private set; } = 0;
    public event Action<int> OnHeartsChanged;

    public void AddHearts(int amount)
    {
        Hearts += amount;
        OnHeartsChanged?.Invoke(Hearts);
    }
}

// GoldManager.cs
public class GoldManager
{
    public int Gold { get; private set; } = 0;
    public event Action<int> OnGoldChanged;

    public void AddGold(int amount)
    {
        Gold += amount;
        OnGoldChanged?.Invoke(Gold);
    }
}

// SeedManager.cs
public class SeedManager
{
    public int SeedCount { get; private set; } = 0;
    public event Action<int> OnSeedCountChanged;

    public void AddAnimals(int amount)
    {
        SeedCount += amount;
        OnSeedCountChanged?.Invoke(SeedCount);
    }
}
// DiamonManager.cs
public class DiamonManager
{
    public int DiamondCount { get; private set; } = 0;
    public event Action<int> OnDiamondCountChanged;

    public void AddAnimals(int amount)
    {
        DiamondCount += amount;
        OnDiamondCountChanged?.Invoke(DiamondCount);
    }
}

