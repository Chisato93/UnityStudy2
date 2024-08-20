using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationPanel : MonoBehaviour
{
    public List<TMP_Text> infortext;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for(int inforType = 0; inforType < infortext.Count; inforType++)
        {
            AnimalCount((UIInformation)inforType);
        }
    }

    // 조금 맛없다.
    public void AnimalCount(UIInformation type)
    {
        TMP_Text typetext = infortext[(int)type];
        switch (type)
        {
            case UIInformation.ANIMAL:
                typetext.text = GameManager.instance.AnimalCount.ToString();
                break;
            case UIInformation.HEART:
                typetext.text = GameManager.instance.HeartCount.ToString();
                break;
            case UIInformation.GOLD:
                typetext.text = GameManager.instance.GoldAmount.ToString();
                break;
            case UIInformation.SEED:
                typetext.text = GameManager.instance.SeedAmount.ToString();
                break;
            case UIInformation.DIAMOND:
                typetext.text = GameManager.instance.DiamondAmount.ToString();
                break;
        }
    }
}
