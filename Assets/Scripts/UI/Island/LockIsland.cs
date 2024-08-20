using TMPro;
using UnityEngine;

public class LockIsland : MonoBehaviour
{
    public TMP_Text islandName;

    public void SetData(IslandData island)
    {
        islandName.text = island.islandName;
    }
}