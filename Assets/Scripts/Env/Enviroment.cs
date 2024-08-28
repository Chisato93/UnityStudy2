using System;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    public List<Island> islandsList;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for(int i = 0; i < islandsList.Count; i++)
        {
            if (DataManager.instance.islandDatas[i].unlockisland == false)
                break;

            islandsList[i].gameObject.SetActive(true);
            islandsList[i].islandID = DataManager.instance.islandDatas[i].islandID;
            islandsList[i].islandLevel = DataManager.instance.islandDatas[i].islandLevel;
            islandsList[i].GetGoldAmount = DataManager.instance.islandDatas[i].moneyDrop;
            islandsList[i].GetHeartAmount = DataManager.instance.islandDatas[i].heartDrop;
        }
    }

    public void UpdateIsland()
    {
        Init();
    }
}
