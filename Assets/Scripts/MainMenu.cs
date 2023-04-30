using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject settingsMenu;

    public void GoToSettingsMenu()
    {
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
