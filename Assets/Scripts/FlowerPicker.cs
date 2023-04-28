using UnityEngine;
using UnityEngine.InputSystem;

public class FlowerPicker : MonoBehaviour
{

    private Pickable flowerInReach;

    private PlayerInputActions inputActions;
    private FlowerManager flowerManager;

    // Start is called before the first frame update
    void Start()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += PickFlower;

        flowerManager = FindObjectOfType<FlowerManager>();
    }

    private void PickFlower(InputAction.CallbackContext obj)
    {
        if (flowerInReach == null) return;

        flowerManager.FoundFlower();
        flowerInReach.Found();
        flowerInReach = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Pickable pickable = other.GetComponent<Pickable>();
        if (pickable == null || pickable.HasBeenFound()) return;

        flowerInReach = pickable;
    }

    private void OnTriggerExit(Collider other)
    {
        Pickable pickable = other.GetComponent<Pickable>();
        if (pickable == null) return;

        flowerInReach = null;
    }
}
