using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    [SerializeField]
    private AudioClip[] musicClips;
    [SerializeField]
    private AudioClip[] pickSoundEffectClips;

    private AudioSource musicSource;
    public enum MusicState
    {
        TitleMenu,
        GameScene
    }
    [SerializeField] private MusicState currentMusicState;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            musicSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        Play(currentMusicState);
    }

    public void Play(MusicState st)
    {
        if (musicClips.Length <= 0) { return;}
        if (musicSource.clip != null && musicSource.isPlaying)
        {
            Stop();
        }
        switch (st)
        {
            case MusicState.TitleMenu:
                currentMusicState = MusicState.TitleMenu;
                musicSource.clip = musicClips[0];
                musicSource.Play();
                break;
            case MusicState.GameScene:
                currentMusicState = MusicState.GameScene;
                musicSource.clip = musicClips[1];
                musicSource.Play();
                break;
            default:
                break;
        }
    }
    public void Stop()
    {
        StartCoroutine(FadeOut(1f));
    }
    public void PlayOneShot(Vector3 loc)
    {

    }

    private IEnumerator FadeOut(float duration)
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / duration;
            yield return new WaitForEndOfFrame();
        }

        musicSource.Stop();
        musicSource.clip = null;
        musicSource.volume = startVolume;

        yield break;
    }
}
