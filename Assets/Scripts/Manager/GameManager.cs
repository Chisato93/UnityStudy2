using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singlton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        GoldManager = new GoldManager();
        HeartManager = new HeartManager();
        AnimalManager = new AnimalManager();
        SeedManager = new SeedManager();
        DiamonManager = new DiamonManager();

    }
    #endregion

    public GoldManager GoldManager { get; private set; }
    public HeartManager HeartManager { get; private set; }
    public AnimalManager AnimalManager { get; private set; }
    public SeedManager SeedManager { get; private set; }
    public DiamonManager DiamonManager { get; private set; }


    private void Start()
    {
        // Example usage
        GoldManager.OnGoldChanged += UpdateGoldUI;
        HeartManager.OnHeartsChanged += UpdateHeartsUI;
        AnimalManager.OnAnimalCountChanged += UpdateAnimalUI;
        SeedManager.OnSeedCountChanged += UpdateSeedUI;
        DiamonManager.OnDiamondCountChanged += UpdateDiamondUI;
    }

    private void UpdateGoldUI(int newGoldAmount)
    {
        // Update UI or other systems
    }

    private void UpdateHeartsUI(int newHeartAmount)
    {
        // Update UI or other systems
    }

    private void UpdateAnimalUI(int newAnimalCount)
    {
        // Update UI or other systems
    }
    private void UpdateSeedUI(int newSeedCount)
    {
        // Update UI or other systems
    }
    private void UpdateDiamondUI(int newDiamondCount)
    {
        // Update UI or other systems
    }
}
