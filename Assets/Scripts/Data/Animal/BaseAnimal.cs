using UnityEngine;

public class BaseAnimal : MonoBehaviour
{
    protected AnimalData animalData;

    public void Init(AnimalData data)
    {
        animalData = data;
        SetData();
    }
    public virtual void SetData() { }

    public void ChangeAnimal(AnimalUnLockType type)
    {
        Destroy(gameObject);
        PetShopPanel animalPanel = GetComponentInParent<PetShopPanel>();
        BaseAnimal newPet = animalPanel.GenerateAnimal(type);
        newPet.Init(animalData);
        newPet.transform.SetSiblingIndex(transform.GetSiblingIndex());
    }
}
