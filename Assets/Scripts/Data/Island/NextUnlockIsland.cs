using System;
using TMPro;
using UnityEngine;

public class NextUnlockIsland : BaseIsland
{
    public TMP_Text islandName;
    public TMP_Text price;

    public override void SetData()
    {
        islandName.text = islandData.islandName;
        price.text = islandData.price.ToString();
    }

    public override void OnClickIslandButton()
    {
        if(GameManager.instance.GoldManager.Gold >= islandData.price)
        {
            GameManager.instance.GoldManager.AddGold(-islandData.price);
            Unlock();
        }
        else
        {
            WarningUI panel = GetComponentInParent<WarningUI>();
            panel.ShowWarningMessage();
        }
    }

    private void Unlock()
    {
        ChangeIsland(IslandUnLockType.Unlock);
        islandData.unlockisland = true;

        // 다음 섬 화면에 노출

        int nextindex = transform.GetSiblingIndex() + 1;

        Transform parentTransform = transform.parent;
        if (nextindex >= parentTransform.childCount)
            return;

        parentTransform.GetChild(nextindex).GetComponent<BaseIsland>().ChangeIsland(IslandUnLockType.NextUnlock);

        DataManager dataManager = FindObjectOfType<DataManager>();
        
        dataManager.nextIsland = parentTransform.GetChild(nextindex).GetComponent<BaseIsland>().islandData;
        dataManager.CSVSave(DataType.Island);
    }
}