using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private UIManager uiManager;
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    public void OnClickButton(string shopName)
    {
        switch(shopName)
        {
            case "PetShop":
                {
                    uiManager.OpenUI(UIType.PetShop);
                    break;
                }
            case "IslandShop":
                {
                    uiManager.OpenUI(UIType.IslandShop);
                    break;
                }
            case "Upgrade":
                {
                    uiManager.OpenUI(UIType.Upgrade);
                    break;
                }
            case "Buy":
                {
                    uiManager.OpenUI(UIType.BuyIsland);
                    break;
                }
        }
    }
}
