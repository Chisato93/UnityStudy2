using TMPro;
using UnityEngine;

public class UnlockIsland : MonoBehaviour
{
    private IslandData islandData;
    public TMP_Text islandLevel;
    public TMP_Text islandName;
    public TMP_Text price;
    public TMP_Text dropMoney;
    public TMP_Text dropHeart;

    public void Init(IslandData data)
    {
        islandData = data;
    }
    public void SetData()
    {
        islandLevel.text = islandData.islandLevel.ToString();
        islandName.text = islandData.islandName;
        price.text = islandData.price.ToString();
        dropMoney.text = islandData.moneyDrop.ToString();
        dropHeart.text = islandData.heartDrop.ToString(); // heartDrop 정보가 있다면 설정
    }

    public void OnClickLevelUp()
    {
        islandData.islandLevel++;

        SetData();

        DataManager dataManager = FindObjectOfType<DataManager>();
        dataManager.CSVSave(DataType.Island);

    }
}