using UnityEngine;

public class Pickable : MonoBehaviour
{

    [SerializeField] 
    private string flowerName;

    [SerializeField]
    private Material materialSource;
    [SerializeField]
    private MeshRenderer meshRenderer;

    private bool isHighlighted;

    private void Awake()
    {
        if (materialSource != null && meshRenderer != null)
        {
            meshRenderer.material = Instantiate(materialSource);
        }
    }

    public void Pick()
    {
        Destroy(this.gameObject);
    }

    public string GetName() { 
        return flowerName; 
    }

    public void Highlight(bool bl)
    {
        isHighlighted = bl;
        if(isHighlighted)
        {
            meshRenderer.material.SetFloat("_Highlight", 1f);
        }
        else
        {
            meshRenderer.material.SetFloat("_Highlight", 0f);
        }
    }
}
