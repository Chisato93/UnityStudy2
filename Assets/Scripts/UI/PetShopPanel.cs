using System;
using TMPro;
using UnityEngine;

public enum AnimalUnLockType
{
    Unlock,
    Lock,
    NotOpen,
}

public class PetShopPanel : MonoBehaviour
{
    public GameObject AnimalList;
    public GameObject SpecialAnimalList;

    public Transform ContentPos;
    public GameObject unlockPrefab;
    public GameObject lockPrefab;
    public GameObject notOpenPrefab;
    private DataManager dataManager;

    public TMP_Text animalCount;

    private void Awake()
    {
        dataManager = FindObjectOfType<DataManager>();
        ToggleAnimal(true);
        animalCount.text = GameManager.instance.AnimalManager.AnimalCount.ToString();
        Init();
    }

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        if (dataManager.animalDatas.Count <= 0)
            return;
        // 기존에 생성된 자식 오브젝트들을 모두 제거합니다.
        foreach (Transform child in ContentPos)
        {
            Destroy(child.gameObject);
        }

        // 새 데이터를 기반으로 오브젝트를 다시 생성합니다.
        for (int i = 0; i < dataManager.animalDatas.Count; i++)
        {
            BaseAnimal go = null;

            if (dataManager.animalDatas[i].animalName == "NotOpen")
            {
                go = GenerateAnimal(AnimalUnLockType.NotOpen);
                go.Init(dataManager.animalDatas[i]);
                continue;
            }
            if (dataManager.animalDatas[i].unlockAnimal)
            {
                go = GenerateAnimal(AnimalUnLockType.Unlock);
            }
            else
            {
                if (dataManager.islandDatas[i].unlockisland)
                {
                    go = GenerateAnimal(AnimalUnLockType.Lock);
                }
                else
                {
                    go = GenerateAnimal(AnimalUnLockType.NotOpen);
                }
            }
            go.Init(dataManager.animalDatas[i]);
        }

        // 동물 수를 갱신합니다.
        animalCount.text = GameManager.instance.AnimalManager.AnimalCount.ToString();
    }

    public BaseAnimal GenerateAnimal(AnimalUnLockType type)
    {
        switch (type)
        {
            case AnimalUnLockType.Unlock:
                return Instantiate(unlockPrefab, ContentPos).GetComponent<BaseAnimal>();
            case AnimalUnLockType.Lock:
                return Instantiate(lockPrefab, ContentPos).GetComponent<BaseAnimal>();
            case AnimalUnLockType.NotOpen:
                return Instantiate(notOpenPrefab, ContentPos).GetComponent<BaseAnimal>();
            default:
                Debug.LogError("Wrong Animal Type");
                return null;
        }
    }

    private void ToggleAnimal(bool animalActive)
    {
        AnimalList.SetActive(animalActive);
        SpecialAnimalList.SetActive(!animalActive);
    }

    public void ToggleAnimalButton(string name)
    {
        ToggleAnimal(name == "Animal");
    }
}
