using UnityEngine;

public class FlowerManager : MonoBehaviour
{

    [SerializeField]
    private int maxAmountFlowers;

    [SerializeField]
    private FlowerAmountDisplay flowerAmountDisplay;

    private int foundFlowers = 0;

    public void FoundFlower()
    {
        foundFlowers++;
        flowerAmountDisplay.SetAmount(foundFlowers);
    }
}
