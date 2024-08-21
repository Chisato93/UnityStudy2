using UnityEngine;

public class BaseIsland : MonoBehaviour
{
    public IslandData islandData { get; set; }

    public void Init(IslandData data)
    {
        islandData = data;
        SetData();
    }
    public virtual void SetData() { }

    public void ChangeIsland(IslandUnLockType type)
    {
        Destroy(gameObject);
        IslandPanel islandPanel = GetComponentInParent<IslandPanel>();
        BaseIsland newIsland = islandPanel.GenerateIsland(type);
        newIsland.Init(islandData);
        newIsland.transform.SetSiblingIndex(transform.GetSiblingIndex());
    }
}
