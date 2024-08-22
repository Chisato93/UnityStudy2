using UnityEngine;
using UnityEngine.EventSystems;

public class Island : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(UIManager.instance.CanUseOpenUI())
            UIManager.instance.OpenUI(UIType.BuyIsland);
    }

}
