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
        inputActions.Journal.OpenJournal.performed += OnToggleJournal;
        inputActions.Journal.CloseJournal.performed += OnCloseJournal;
    }

    public void ToggleJournal()
    {
        if (journal_Panel.activeSelf)
        {
            CloseJournal();
        }
        else
        {
            OpenJournal();
        }
    }

    public void CloseJournal()
    {
        journal_Panel.SetActive(false);
    }


    public void OpenJournal()
    {
        journal_Panel.SetActive(true);
    }

    private void OnToggleJournal(InputAction.CallbackContext obj)
    {
        ToggleJournal();
    }

    private void OnCloseJournal(InputAction.CallbackContext obj)
    {
        CloseJournal();
    }
}
