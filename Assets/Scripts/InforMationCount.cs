using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InforMationCount : MonoBehaviour
{
    private int count;
    public TMP_Text resourceCount;

    private void Start()
    {
        // 로드할게 있으면 count를 불러옴 없으면 그냥 0
        count = 0;
    }

    public void ChangeAmount(int amount)
    {
        count += amount;
        Global.SetUI(resourceCount, count);
    }
}
