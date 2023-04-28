using UnityEngine;
using UnityEngine.InputSystem;

public class Journal : MonoBehaviour
{

    [SerializeField] 
    private GameObject journal_Panel;

    private void Awake()
    {
        PlayerInputActions inputActions = new PlayerInputActions();
        inputActions.Journal.Enable();
        inputActions.Journal.OpenJournal.performed += OpenJounal;
    }


    public void OpenJounal(InputAction.CallbackContext obj)
    {
        Debug.Log("called");
        journal_Panel.SetActive(!journal_Panel.activeSelf);
    }
}
