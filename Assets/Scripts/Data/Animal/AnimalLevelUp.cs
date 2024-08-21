using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalLevelUp : BaseAnimal
{
    public Image    animalImge;
    public TMP_Text animalLevel;
    public TMP_Text animalName;
    public TMP_Text animalCount;
    public TMP_Text animalEffect;
    public TMP_Text animalPrice;

    public override void SetData()
    {
        // 여기서부터 입력받은게 출력되게 만들기.
        animalImge.sprite = Resources.Load<Sprite>(animalData.imagePath);
        animalLevel.text = "lv. " + animalData.animalLevel.ToString();
        animalName.text = animalData.animalName;
        animalCount.text = animalData.animalCount.ToString();
        animalEffect.text = "+ " + animalData.animalEffect.ToString() + " %";
        animalPrice.text = animalData.price.ToString();
    }

    private const float priceUprising = 1.2f;
    public void OnClickLevelUp()
    {
        animalData.animalLevel++;
        animalData.price = (int)(animalData.price * priceUprising);
        animalData.animalEffect += 10;
        DataManager dataManager = FindObjectOfType<DataManager>();
        dataManager.CSVSave(DataType.Animal);
        SetData();
    }
}
