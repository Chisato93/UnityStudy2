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

    private void Awake()
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
        rewardImage.sprite = Resources.Load<Sprite>(dataManager.animalDatas[dataManager.nextIsland.islandID].imagePath);
    }

    public void OnClickBuyButton()
    {
        int index = dataManager.GetIslandIndex(dataManager.nextIsland) - 1;
        if (index < 0) return;

        if (GameManager.instance.GoldAmount >= dataManager.islandDatas[index].price)
        {
            GameManager.instance.GoldAmount -= dataManager.islandDatas[index].price;

            dataManager.islandDatas[index+1].unlockisland = true;
            dataManager.CSVSave(DataType.Island);

            UIManager.instance.OpenUI(UIType.Upgrade);
        }
        else
        {
            WarningUI panel = GetComponentInParent<WarningUI>();
            panel.ShowWarningMessage();
        }
    }

}
