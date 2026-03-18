using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1);
        AudioListener.volume = volume;

        if (volumeSlider != null)
        {
            volumeSlider.value = volume;
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}