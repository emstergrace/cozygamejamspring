using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomUIButton : Button
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if(MusicPlayer.instance != null)
        {
            MusicPlayer.instance.PlayOneShot(MusicPlayer.UISounds.Hover);
        }
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        if (MusicPlayer.instance != null)
        {
            MusicPlayer.instance.PlayOneShot(MusicPlayer.UISounds.Open);
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (MusicPlayer.instance != null)
        {
            MusicPlayer.instance.PlayOneShot(MusicPlayer.UISounds.Select);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private const string TitleScene = "TitleScene";
    private const string GameScene = "MainScene";
    private const string LoadingScene = "LoadingScene";
    public void GoToGameScene()
    {
        if(GoToGameSceneCo == null)
        {
            GoToGameSceneCo = StartCoroutine(GoToGameSceneCoroutine());
        }
        
    }
    private Coroutine GoToGameSceneCo;
    private IEnumerator GoToGameSceneCoroutine()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(LoadingScene, UnityEngine.SceneManagement.LoadSceneMode.Additive);

        if (MusicPlayer.instance != null)
        {
            MusicPlayer.instance.Destroy();
            
        }

        yield return new WaitForSeconds(5f);

        AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(GameScene, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(TitleScene);

        LoadingManager.instance.Destroy();

        GoToGameSceneCo = null;
        yield break;
    }
}
