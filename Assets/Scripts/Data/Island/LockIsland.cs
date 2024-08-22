using TMPro;
using UnityEngine;

public class LockIsland : BaseIsland
{
    public TMP_Text islandName;

    public override void SetData()
    {
        islandName.text = islandData.islandName;
    }
}