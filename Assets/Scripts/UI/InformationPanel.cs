using System.Collections.Generic;
using TMPro;
using UnityEngine;

//public class InformationPanel : MonoBehaviour
//{
//    private void Start()
//    {
//        Init();
//    }

//    private void Init()
//    {
//        for(int inforType = 0; inforType < infortext.Count; inforType++)
//        {
//            InformationSetting((UIInformation)inforType);
//        }
//    }

//    public void InformationSetting(UIInformation type)
//    {
//        TMP_Text typetext = infortext[(int)type];
//        switch (type)
//        {
//            case UIInformation.ANIMAL:
//                typetext.text = GameManager.instance.AnimalManager.AnimalCount.ToString();
//                break;
//            case UIInformation.HEART:
//                typetext.text = GameManager.instance.HeartManager.Hearts.ToString();
//                break;
//            case UIInformation.GOLD:
//                typetext.text = GameManager.instance.GoldManager.Gold.ToString();
//                break;
//            case UIInformation.SEED:
//                typetext.text = GameManager.instance.SeedManager.SeedCount.ToString();
//                break;
//            case UIInformation.DIAMOND:
//                typetext.text = GameManager.instance.DiamonManager.DiamondCount.ToString();
//                break;
//        }
//    }
// InformationPanel.cs
public class InformationPanel : MonoBehaviour
{
    public List<TMP_Text> infortext;


    private void OnEnable()
    {
        GameManager.instance.GoldManager.OnGoldChanged += UpdateGoldText;
        GameManager.instance.HeartManager.OnHeartsChanged += UpdateHeartsText;
        GameManager.instance.AnimalManager.OnAnimalCountChanged += UpdateAnimalText;
        GameManager.instance.SeedManager.OnSeedCountChanged += UpdateSeedText;
        GameManager.instance.DiamonManager.OnDiamondCountChanged += UpdateDiamondText;
    }

    private void OnDisable()
    {
        GameManager.instance.GoldManager.OnGoldChanged -= UpdateGoldText;
        GameManager.instance.HeartManager.OnHeartsChanged -= UpdateHeartsText;
        GameManager.instance.AnimalManager.OnAnimalCountChanged -= UpdateAnimalText;
        GameManager.instance.SeedManager.OnSeedCountChanged -= UpdateSeedText;
        GameManager.instance.DiamonManager.OnDiamondCountChanged -= UpdateDiamondText;
    }

    private void UpdateGoldText(int newGoldAmount)
    {
        infortext[(int)UIInformation.GOLD].text = GameManager.instance.GoldManager.Gold.ToString();
    }

    private void UpdateHeartsText(int newHeartAmount)
    {
        infortext[(int)UIInformation.HEART].text = GameManager.instance.HeartManager.Hearts.ToString();
    }

    private void UpdateAnimalText(int newAnimalCount)
    {
        infortext[(int)UIInformation.ANIMAL].text = GameManager.instance.AnimalManager.AnimalCount.ToString();
    }
    private void UpdateSeedText(int newAnimalCount)
    {
        infortext[(int)UIInformation.SEED].text = GameManager.instance.SeedManager.SeedCount.ToString();
    }
    private void UpdateDiamondText(int newAnimalCount)
    {
        infortext[(int)UIInformation.DIAMOND].text = GameManager.instance.DiamonManager.DiamondCount.ToString();
    }
}

