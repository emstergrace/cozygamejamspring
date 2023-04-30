using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    private bool isPaused = false;
    private RectTransform panel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            panel = transform.GetChild(0).GetComponent<RectTransform>();
            PlayerInputActions inputActions = new PlayerInputActions();
            inputActions.Player.Enable();
            inputActions.Player.Pause.performed += Pause_performed;
        }
    }
    private void Update()
    {
        
    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            UnPauseGame();
        }
    }

    public void PauseGame()
    {
        if(MusicPlayer.instance != null)
        {
            MusicPlayer.instance.Play(MusicPlayer.MusicState.Paused);
        }
        panel.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void UnPauseGame()
    {
        if (MusicPlayer.instance != null)
        {
            MusicPlayer.instance.Play(MusicPlayer.MusicState.GameScene);
        }
        panel.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
}
