using System;
using System.Collections;
using UnityEngine;

public enum IslandUnLockType
{
    Unlock,
    NextUnlock,
    Lock,
}
public class IslandPanel : MonoBehaviour
{
    public Transform ContentPos;
    public GameObject UnlockIsland;
    public GameObject NextUnlockIsland;
    public GameObject LockIsland;

    public GameObject warning;
    const float showTime = 1.5f;

    private DataManager dataManager;

    private void Start()
    {
        dataManager = FindObjectOfType<DataManager>();

        Init();
    }

    private void Init()
    {
        bool firstTime = false;
        for(int i = 0; i < dataManager.islandDatas.Count; i++)
        {
            BaseIsland go = null;
            if (dataManager.islandDatas[i].unlockisland)
            {
                go = GenerateIsland(IslandUnLockType.Unlock);
            }
            else
            {
                if(!firstTime)
                {
                    go = GenerateIsland(IslandUnLockType.NextUnlock);
                    dataManager.nextIsland = dataManager.islandDatas[i];
                    firstTime = !firstTime;
                }
                else
                {
                    go = GenerateIsland(IslandUnLockType.Lock);
                }
            }
            go.Init(dataManager.islandDatas[i]);
        }
    }

    public BaseIsland GenerateIsland(IslandUnLockType type)
    {
        switch (type)
        {
            case IslandUnLockType.Unlock:
                return Instantiate(UnlockIsland, ContentPos).GetComponent<BaseIsland>();
            case IslandUnLockType.NextUnlock:
                return Instantiate(NextUnlockIsland, ContentPos).GetComponent<BaseIsland>();
            case IslandUnLockType.Lock:
                return Instantiate(LockIsland, ContentPos).GetComponent<BaseIsland>();
            default:
                Debug.Log("Wrong Island Type");
                return null;
        }
    }

    public void ShowWarningMessage()
    {
        StartCoroutine(warningMessage());
    }
    private IEnumerator warningMessage()
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(showTime);
        warning.SetActive(false);
    }
}
