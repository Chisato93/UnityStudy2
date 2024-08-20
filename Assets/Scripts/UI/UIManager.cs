using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType
{
    Upgrade,
    PetShop,
    IslandShop,
    BuyIsland,
}

public class UIManager : MonoBehaviour
{
    public List<GameObject> UIPanels;
    public const int Upgrade = 0, PetshopPanel = 1, IslandshopPanel = 2;
    private void Start()
    {
        foreach(GameObject go in UIPanels)
        {
            // 업그레이드는 제외시켜야함.
            go.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIPanels[Upgrade].SetActive(true);
        }
    }

    public void OpenUI(UIType type)
    {
        for(int i = 0; i < UIPanels.Count; i++)
        {
            if ((int)type == i)
                UIPanels[i].SetActive(true);
            else
                UIPanels[i].SetActive(false);
        }
    }

}
