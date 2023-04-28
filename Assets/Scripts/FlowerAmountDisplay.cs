using TMPro;
using UnityEngine;

public class FlowerAmountDisplay : MonoBehaviour
{

    [SerializeField]
    private TMP_Text AmountDisplay;

    public void SetAmount(int amount)
    {
        if (amount <= 0)
        {
            AmountDisplay.text = "-/6";
            return;
        }
        AmountDisplay.text = amount.ToString() + "/6";
    }
}
