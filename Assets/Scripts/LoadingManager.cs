using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance;
    [SerializeField] private string LoadingScene = "LoadingScene";

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
        }
    }

    private void Start()
    {
        StartCoroutine (FadeIn());
    }
    public void Destroy()
    {
        StartCoroutine (FadeOut());
    }

    private IEnumerator FadeIn()
    {
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += 1f * Time.deltaTime;
            yield return null;
        }
        yield break;
    }
    private IEnumerator FadeOut()
    {
        while(canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= 1f * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForEndOfFrame();
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(LoadingScene);
        yield break;
    }
}
