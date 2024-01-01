using UnityEngine;
using UnityEngine.UI;


public class MainMenuMusic : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundSlider;

    void Start()
    {
        AudioManager.instance.PlayMusic("MainMenuMusic", 1);
        AudioManager.instance.PlayMusic("MainMenuMusic");

        if (AudioManager.instance != null)
        {
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            soundSlider.onValueChanged.AddListener(SetSoundVolume);
        }
        else
        {
            Debug.LogError("AudioManager not found!");
        }
    }

    private void SetMusicVolume(float volume)
    {
        AudioManager.instance.SetMusicVolume(volume);
    }

    private void SetSoundVolume(float volume)
    {
        AudioManager.instance.SetSoundVolume(volume);
    }
}
