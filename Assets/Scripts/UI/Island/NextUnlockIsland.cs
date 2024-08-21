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

    public void OnClickLevelUp()
    {
        if(GameManager.instance.GoldAmount >= islandData.price)
        {
            GameManager.instance.GoldAmount -= islandData.price;
            Unlock();
        }
        else
        {
            IslandPanel panel = GetComponentInParent<IslandPanel>();
            panel.ShowWarningMessage();
        }
    }

    private void Unlock()
    {
        ChangeIsland(IslandUnLockType.Unlock);
        islandData.unlockisland = true;

        int nextindex = transform.GetSiblingIndex() + 1;

        Transform parentTransform = transform.parent;
        if (nextindex >= parentTransform.childCount)
            return;

        parentTransform.GetChild(nextindex).GetComponent<BaseIsland>().ChangeIsland(IslandUnLockType.NextUnlock);

        DataManager dataManager = FindObjectOfType<DataManager>();
        dataManager.CSVSave(DataType.Island);
    }
}