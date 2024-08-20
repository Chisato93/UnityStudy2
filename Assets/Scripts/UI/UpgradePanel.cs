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
        selectedLevelText.text = data.islandLevel.ToString();
        selectedNameText.text = data.islandName.ToString();
        upgradeAmountText.text = data.price.ToString();
        upgradeResultText.text = data.getMoneyAmount.ToString();
    }

    public void UpgradeButton()
    {
        IslandData isd = new IslandData();
        SetUpgradeInfo(isd);
    }
}
