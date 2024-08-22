using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WarningUI : MonoBehaviour
{
    public GameObject warning;
    private const float showTime = 1.5f;

    public void ShowWarningMessage()
    {
        StartCoroutine(warningMessage());
    }
    private IEnumerator warningMessage()
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(showTime);
        warning.SetActive(false);
    }
}



// 오픈안된거 생성안되고 있고,
// 락 해제하면 이상하게 생성된다.
