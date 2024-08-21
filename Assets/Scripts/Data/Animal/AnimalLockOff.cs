using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalLockOff : BaseAnimal
{
    public Image animalImge;
    public TMP_Text animalName;
    public TMP_Text animalPrice;

    public override void SetData()
    {
        animalImge.sprite = Resources.Load<Sprite>(animalData.imagePath);
        animalName.text = animalData.animalName;
        animalPrice.text = animalData.price.ToString();
    }

    public void UnlockButton()
    {
        if(animalData.price <= GameManager.instance.HeartCount)
        {
            GameManager.instance.HeartCount -= animalData.price;
            animalData.unlockAnimal = true;

            ChangeAnimal(AnimalUnLockType.Unlock);

            DataManager dataManager = FindObjectOfType<DataManager>();
            dataManager.CSVSave(DataType.Animal);
        }
        else
        {
            WarningUI warningUI = GetComponentInParent<WarningUI>();
            warningUI.ShowWarningMessage();
        }
    }
}
