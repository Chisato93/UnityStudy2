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

}
