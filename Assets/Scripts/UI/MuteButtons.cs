using UnityEngine;
using UnityEngine.UI;

public class MuteButtons : MonoBehaviour
{
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    private bool isSoundMuted = false;
    private bool isMusicMuted = false;

    private Button soundButton;
    private Button musicButton;

    void Start()
    {
        soundButton = GetComponentInChildren<Button>(true);
        musicButton = GetComponentInChildren<Button>(true);

        if (soundButton != null)
            soundButton.onClick.AddListener(ToggleSoundMute);

        if (musicButton != null)
            musicButton.onClick.AddListener(ToggleMusicMute);

        UpdateSoundButtonImage();
        UpdateMusicButtonImage();
    }


    void ToggleSoundMute()
    {
        isSoundMuted = !isSoundMuted;
        UpdateSoundButtonImage();

        if (isSoundMuted)
        {
            AudioManager.instance.MuteSound();
        }
        else
        {
            AudioManager.instance.UnmuteSound();
        }
    }

    void ToggleMusicMute()
    {
        isMusicMuted = !isMusicMuted;
        UpdateMusicButtonImage();

        if (isMusicMuted)
        {
            AudioManager.instance.MuteMusic();
        }
        else
        {
            AudioManager.instance.UnmuteMusic();
        }
    }

    void UpdateSoundButtonImage()
    {
        soundButton.image.sprite = isSoundMuted ? soundOffSprite : soundOnSprite;
    }

    void UpdateMusicButtonImage()
    {
        musicButton.image.sprite = isMusicMuted ? musicOffSprite : musicOnSprite;
    }
}
