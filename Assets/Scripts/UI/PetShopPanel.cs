using UnityEngine;

public class PetShopPanel : MonoBehaviour
{
    public GameObject AnimalList;
    public GameObject SpecialAnimalList;

    private void Start()
    {
        ToggleAnimal(true);
    }

    private void ToggleAnimal(bool animalActive)
    {
        AnimalList.SetActive(animalActive);
        SpecialAnimalList.SetActive(!animalActive);
    }

    public void ToggleAnimalButton(string name)
    {
        if (name == "Animal")
            ToggleAnimal(true);
        else 
            ToggleAnimal(false);

    }
}
