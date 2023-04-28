using UnityEngine;

public class Pickable : MonoBehaviour
{

    private bool found = false;

    public void Found()
    {
        found = true;
    }

    public bool HasBeenFound()
    {
        return found;
    }
}
