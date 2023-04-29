using UnityEngine;

public class FlowerManager : MonoBehaviour
{

    [SerializeField]
    private int maxAmountFlowers;

    [SerializeField]
    private FlowerAmountDisplay flowerAmountDisplay;

    [SerializeField]
    private CentralTable centralTable;

    private int foundFlowers = 0;

    public void FoundFlower(string flowerName)
    {
        foundFlowers++;
        flowerAmountDisplay.SetAmount(foundFlowers);
        centralTable.AddFlower(flowerName);
    }
}
