using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{

    [SerializeField]
    private AudioMixer audioMixer;

    public void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}
