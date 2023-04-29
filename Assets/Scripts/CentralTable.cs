using System;
using UnityEngine;

public class CentralTable : MonoBehaviour
{

    [SerializeField]
    private KeyValuePair[] flowers;

    public void AddFlower(string flowerName)
    {
        foreach (KeyValuePair flower in flowers)
        {
            if (flower.flowerName == flowerName)
            {
                flower.flowerInPot.SetActive(true);
            }
        }
    }

    [Serializable]
    private struct KeyValuePair
    {
        public string flowerName;
        public GameObject flowerInPot;

        public KeyValuePair(string flowerName, GameObject flowerInPot)
        {
            this.flowerName = flowerName;
            this.flowerInPot = flowerInPot;
        }
    }
}
