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
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        foreach (GameObject go in UIPanels)
        {
            go.SetActive(false);
        }
        UIPanels[(int)UIType.Upgrade].SetActive(true);
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
