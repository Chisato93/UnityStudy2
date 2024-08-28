using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    public TMP_Text selectedLevelText;
    public TMP_Text selectedNameText;
    public TMP_Text upgradeResultText;
    public TMP_Text upgradeAmountText;

    public void SetUpgradeInfo(IslandData data)
    {
        selectedLevelText.text = "Lv. " + data.islandLevel.ToString();
        selectedNameText.text = data.islandName.ToString();
        upgradeAmountText.text = data.price.ToString();
        upgradeResultText.text = data.moneyDrop.ToString();
    }

    public void UpgradeButton()
    {
        IslandData island = DataManager.instance.currentIsland;

        if (island == null)
            return;

        SetUpgradeInfo(island);
    }
}
