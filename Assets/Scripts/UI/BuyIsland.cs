using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyIsland : MonoBehaviour
{
    public TMP_Text islandName;
    public TMP_Text islandDropMoney;
    public TMP_Text islandPrice;
    public Image rewardImage;

    private DataManager dataManager;

    private void Start()
    {
        dataManager = FindObjectOfType<DataManager>();
        Init();
    }

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        IslandData data = dataManager.nextIsland;
        islandName.text = data.islandName;
        islandDropMoney.text = data.moneyDrop.ToString() + " / 5 sec";
        islandPrice.text = data.price.ToString();
        rewardImage.sprite = Resources.Load<Sprite>("Sprtie/dog-house");
    }
}
