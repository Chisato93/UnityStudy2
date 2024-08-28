using TMPro;
using UnityEngine;

public class UnlockIsland : BaseIsland
{
    public TMP_Text islandLevel;
    public TMP_Text islandName;
    public TMP_Text price;
    public TMP_Text dropMoney;
    public TMP_Text dropHeart;

    public override void SetData()
    {
        islandLevel.text = "Lv. " + islandData.islandLevel.ToString();
        islandName.text = islandData.islandName;
        price.text = islandData.price.ToString();
        dropMoney.text = islandData.moneyDrop.ToString();
        dropHeart.text = islandData.heartDrop.ToString(); // heartDrop 정보가 있다면 설정
    }

    private const float priceUprising = 1.2f;
    public override void OnClickIslandButton()
    {
        islandData.islandLevel++;
        islandData.price = (int)(islandData.price * priceUprising);
        DataManager dataManager = FindObjectOfType<DataManager>();
        dataManager.CSVSave(DataType.Island);
        SetData();
    }
}