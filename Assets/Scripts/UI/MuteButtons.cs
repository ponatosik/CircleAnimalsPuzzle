using CircleAnimalsPuzzle.Systems;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CircleAnimalsPuzzle.UI
{
	public class MuteButtons : MonoBehaviour
	{
		public Sprite SoundOnSprite;
		public Sprite SoundOffSprite;
		public Sprite MusicOnSprite;
		public Sprite MusicOffSprite;
		public Button SoundButton;
		public Button MusicButton;

		private bool _isSoundMuted = false;
		private bool _isMusicMuted = false;

		void ToggleSoundMute()
		{
			_isSoundMuted = !_isSoundMuted;

			if (_isSoundMuted)
			{
				AudioManager.Instance.MuteSound();
				Debug.Log("Sound Muted");
			}
			else
			{
				AudioManager.Instance.UnmuteSound();
				Debug.Log("Sound Unmuted");
			}

			UpdateSoundButtonImage();
		}

		void ToggleMusicMute()
		{
			_isMusicMuted = !_isMusicMuted;

			if (_isMusicMuted)
			{
				AudioManager.Instance.MuteMusic();
				Debug.Log("Music Muted");
			}
			else
			{
				AudioManager.Instance.UnmuteMusic();
				Debug.Log("Music Unmuted");
			}

			UpdateMusicButtonImage();
		}

		void UpdateSoundButtonImage()
		{
			if (SoundButton != null)
			{
				SoundButton.image.sprite = _isSoundMuted ? SoundOffSprite : SoundOnSprite;
			}
			else 
			{
				Debug.LogError("Sound button is not assigned!");
			}
		}

		void UpdateMusicButtonImage()
		{
			if (MusicButton != null)
			{
				MusicButton.image.sprite = _isMusicMuted ? MusicOffSprite : MusicOnSprite;
			}
			else
			{ 
				Debug.LogError("Music button is not assigned!");
			}
		}
	}
}