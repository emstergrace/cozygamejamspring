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
        inputActions.Journal.CloseJournal.performed += CloseJounal;
    }


    public void OpenJounal(InputAction.CallbackContext obj)
    {
        journal_Panel.SetActive(!journal_Panel.activeSelf);
    }

    public void CloseJounal(InputAction.CallbackContext obj)
    {
        journal_Panel.SetActive(false);
    }
}
