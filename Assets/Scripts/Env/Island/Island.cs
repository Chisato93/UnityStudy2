using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Island : MonoBehaviour
{
    private const float delayTime = 3f;

    public int islandID = 0;
    public int islandLevel = 0;
    public int GetGoldAmount { get; set; }
    public int GetHeartAmount { get; set; }


    private void OnEnable()
    {
        InvokeRepeating("GetGold", 0, delayTime);
        InvokeRepeating("GetHeart", 0, delayTime);
    }

    
    private void OnMouseDown()
    {
        if(UIManager.instance.CanUseOpenUI())
        {
            UIManager.instance.OpenUI(UIType.BuyIsland);
            DataManager.instance.currentIsland = DataManager.instance.islandDatas[islandID];
        }
    }

    public void GetGold()
    {
        GameManager.instance.GoldManager.AddGold(GetGoldAmount);
    }

    public void GetHeart()
    {
        GameManager.instance.HeartManager.AddHearts(GetHeartAmount);
    }
}
