using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnClickButton(string shopName)
    {
        switch(shopName)
        {
            case "PetShop":
                {
                    UIManager.instance.OpenUI(UIType.PetShop);
                    break;
                }
            case "IslandShop":
                {
                    UIManager.instance.OpenUI(UIType.IslandShop);
                    break;
                }
            case "Upgrade":
                {
                    UIManager.instance.OpenUI(UIType.Upgrade);
                    break;
                }
            case "Buy":
                {
                    UIManager.instance.OpenUI(UIType.BuyIsland);
                    break;
                }
        }
    }
}
