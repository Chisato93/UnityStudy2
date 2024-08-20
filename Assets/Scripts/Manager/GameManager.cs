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
    }
    #endregion

    public int AnimalCount { get; private set; } = 0;
    public int HeartCount { get; private set; } = 0;
    public int GoldAmount { get; private set; } = 0;
    public int SeedAmount { get; private set; } = 0;
    public int DiamondAmount { get; private set; } = 0;

}
