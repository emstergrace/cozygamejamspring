using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlowerPicker : MonoBehaviour
{

    private List<Pickable> flowersInReach;

    private PlayerInputActions inputActions;
    private FlowerManager flowerManager;

    // Start is called before the first frame update
    void Start()
    {
        flowersInReach = new List<Pickable>();

        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += PickFlower;

        flowerManager = FindObjectOfType<FlowerManager>();
    }

    private void PickFlower(InputAction.CallbackContext obj)
    {
        if (!flowersInReach.Any()) return;

        flowerManager.FoundFlower();
        flowersInReach.First().Found();
        flowersInReach.First().Highlight(false);
        flowersInReach.RemoveAt(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Pickable pickable = other.GetComponent<Pickable>();
        if (pickable == null || pickable.HasBeenFound()) return;

        flowersInReach.Add(pickable);
        pickable.Highlight(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Pickable pickable = other.GetComponent<Pickable>();
        if (pickable == null) return;

        pickable.Highlight(false);
        flowersInReach.Remove(pickable);
    }
}
