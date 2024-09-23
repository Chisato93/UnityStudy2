using UnityEngine;

public class AnimalOP : MonoBehaviour
{
    public GameObject animalPrefab;
    const float spawn_Hight = 0.8f;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            GenerateAnimal();
        }
    }

    public void GenerateAnimal()
    {
        GameObject go = Instantiate(animalPrefab, this.transform);
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + spawn_Hight, transform.position.z);
        go.transform.position = newPosition;
        go.name = animalPrefab.name;
        GameManager.instance.AnimalManager.AddAnimals(1);
    }
}
