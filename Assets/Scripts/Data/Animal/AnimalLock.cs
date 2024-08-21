using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalLock : BaseAnimal
{
    public Image animalImge;
    public TMP_Text animalName;
    public TMP_Text condition;

    public override void SetData()
    {
        animalImge.sprite = Resources.Load<Sprite>(animalData.imagePath);
        animalName.text = animalData.animalName;

        condition.text = "Need xxx Unlcok";
    }
}
