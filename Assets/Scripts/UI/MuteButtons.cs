using CircleAnimalsPuzzle.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace CircleAnimalsPuzzle.UI
{
	public class MuteButtons : MonoBehaviour
	{
		public Sprite soundOnSprite;
		public Sprite soundOffSprite;
		public Sprite musicOnSprite;
		public Sprite musicOffSprite;

		public Button soundButton;
		public Button musicButton;

		private bool isSoundMuted = false;
		private bool isMusicMuted = false;

		void ToggleSoundMute()
		{
			isSoundMuted = !isSoundMuted;

			if (isSoundMuted)
			{
				AudioManager.instance.MuteSound();
				Debug.Log("Sound Muted");
			}
			else
			{
				AudioManager.instance.UnmuteSound();
				Debug.Log("Sound Unmuted");
			}

			UpdateSoundButtonImage();
		}

		void ToggleMusicMute()
		{
			isMusicMuted = !isMusicMuted;

			if (isMusicMuted)
			{
				AudioManager.instance.MuteMusic();
				Debug.Log("Music Muted");
			}
			else
			{
				AudioManager.instance.UnmuteMusic();
				Debug.Log("Music Unmuted");
			}

			UpdateMusicButtonImage();
		}

		void UpdateSoundButtonImage()
		{
			if (soundButton != null)
				soundButton.image.sprite = isSoundMuted ? soundOffSprite : soundOnSprite;
			else
				Debug.LogError("Sound button is not assigned!");
		}

		void UpdateMusicButtonImage()
		{
			if (musicButton != null)
				musicButton.image.sprite = isMusicMuted ? musicOffSprite : musicOnSprite;
			else
				Debug.LogError("Music button is not assigned!");
		}
	}
}