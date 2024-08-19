using TMPro;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static void SetUI(TMP_Text text, int amount)
    {
        text.text = amount.ToString();
    }
}
