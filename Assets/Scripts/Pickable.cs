using UnityEngine;

public class Pickable : MonoBehaviour
{

    [SerializeField]
    private Material materialSource;
    [SerializeField]
    private MeshRenderer meshRenderer;

    private bool isHighlighted;
    private bool found = false;

    private void Awake()
    {
        if (materialSource != null && meshRenderer != null)
        {
            meshRenderer.material = Instantiate(materialSource);
        }
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
