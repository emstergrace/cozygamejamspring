using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
