using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Journal : MonoBehaviour
{

    [SerializeField]
    private KeyValuePair[] flowerSections;

    [SerializeField] 
    private GameObject journal_Panel;

    private void Awake()
    {
        PlayerInputActions inputActions = new PlayerInputActions();
        inputActions.Journal.Enable();
        inputActions.Journal.OpenJournal.performed += OnToggleJournal;
        inputActions.Journal.CloseJournal.performed += OnCloseJournal;
    }

    public void ActivateFlower(string flowerName)
    {
        OpenJournal();

        foreach (KeyValuePair flowerSection in flowerSections)
        {
            if (flowerSection.flowerName == flowerName)
            {
                flowerSection.flowerSection.StartWritingFlowerSection();
            }
        }
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

        foreach (KeyValuePair flowerSection in flowerSections)
        {
           flowerSection.flowerSection.FinishWritingIfInProcess();
        }
        
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


    [Serializable]
    private struct KeyValuePair
    {
        public string flowerName;
        public FlowerSection flowerSection;

        public KeyValuePair(string flowerName, FlowerSection flowerSection)
        {
            this.flowerName = flowerName;
            this.flowerSection = flowerSection;
        }
    }
}
