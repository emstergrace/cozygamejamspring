using UnityEngine;

public class Pickable : MonoBehaviour
{

    private bool found = false;

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
    private void Start()
    {
        
    }

    public void Found()
    {
        found = true;
    }

    public bool HasBeenFound()
    {
        return found;
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
