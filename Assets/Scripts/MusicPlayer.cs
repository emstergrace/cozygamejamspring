using System.Collections;
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
    public enum UISounds
    {
        Open,
        Hover,
        Select,
        Back,
        Close
    }
    public enum JournalSounds
    {
        Open,
        Close
    }
    [SerializeField] private AudioClip[] uiSounds;
    [SerializeField] private AudioClip[] journalSounds;

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
    public void PlayOneShot(UISounds sound)
    {
        switch (sound)
        {
            case UISounds.Open:
                musicSource.PlayOneShot(uiSounds[0]);
                break;
            case UISounds.Hover:
                musicSource.PlayOneShot(uiSounds[1]);
                break;
            case UISounds.Select:
                musicSource.PlayOneShot(uiSounds[2]);
                break;
            case UISounds.Back:
                musicSource.PlayOneShot(uiSounds[3]);
                break;
            case UISounds.Close:
                musicSource.PlayOneShot(uiSounds[4]);
                break;
            default:
                break;
        }
     
    }

    public void PlayOneShot(JournalSounds sound)
    {
        switch (sound)
        {
            case JournalSounds.Open:
                musicSource.PlayOneShot(journalSounds[0]);
                break;
            case JournalSounds.Close:
                musicSource.PlayOneShot(journalSounds[1]);
                break;
            default:
                break;
        }
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
