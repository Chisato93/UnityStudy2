using TMPro;
using UnityEngine;

public class NextUnlockIsland : MonoBehaviour
{
    private IslandData islandData;
    public TMP_Text islandName;
    public TMP_Text price;

    public void Init(IslandData data)
    {
        islandData = data;
    }
    public void SetData()
    {
        islandName.text = islandData.islandName;
        price.text = islandData.price.ToString();
    }

    public void OnClickLevelUp()
    {
        if(GameManager.instance.GoldAmount >= islandData.price)
        {
            GameManager.instance.GoldAmount -= islandData.price;
            // 해금
        }
        else
        {
            IslandPanel panel = GetComponentInParent<IslandPanel>();
            panel.ShowWarningMessage();
        }
    }
}