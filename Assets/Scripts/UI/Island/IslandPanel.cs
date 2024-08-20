using System;
using System.Collections;
using UnityEngine;

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
        bool first = false;
        for(int i = 0; i < dataManager.islandDatas.Count; i++)
        {
            if (dataManager.islandDatas[i].unlockisland)
            {
                UnlockIsland go = Instantiate(UnlockIsland, ContentPos).GetComponent<UnlockIsland>();
                go.Init(dataManager.islandDatas[i]);
            }
            else
            {
                if(!first)
                {
                    NextUnlockIsland go = Instantiate(NextUnlockIsland, ContentPos).GetComponent<NextUnlockIsland>();
                    go.Init(dataManager.islandDatas[i]);
                    first = true;
                }
                else
                {
                    LockIsland go = Instantiate(LockIsland, ContentPos).GetComponent<LockIsland>();
                }
            }
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
