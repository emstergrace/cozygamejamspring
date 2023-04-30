using UnityEngine;

public class ScribblingPlayer : MonoBehaviour
{


    private AudioSource musicSource;
    public static ScribblingPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            musicSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StartScribbling()
    {
        musicSource.Play();
    }

    public void StopScribbling()
    {
        musicSource.Stop();
    }
}
