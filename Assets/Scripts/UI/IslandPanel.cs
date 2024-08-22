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
        if (dataManager.islandDatas.Count <= 0)
            return;
        // 기존에 생성된 자식 오브젝트들을 모두 제거합니다.
        foreach (Transform child in ContentPos)
        {
            Destroy(child.gameObject);
        }
        bool firstTime = false;
        for(int i = 0; i < dataManager.islandDatas.Count; i++)
        {
            BaseIsland go = null;
            if (dataManager.islandDatas[i].islandName == "NotOpen")
            {
                go = GenerateIsland(IslandUnLockType.Lock);
                go.Init(dataManager.islandDatas[i]);
                continue;
            }
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

}
