using CircleAnimalsPuzzle.Systems;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CircleAnimalsPuzzle.UI
{
	public class MainMenuMusic : MonoBehaviour
	{
		[SerializeField]
		private Slider _musicSlider;
		[SerializeField]
		private Slider _soundSlider;

		void Start()
		{
			AudioManager.Instance.PlayMusic("MainMenuMusic", 1);
			AudioManager.Instance.PlayMusic("MainMenuMusic");

			if (AudioManager.Instance != null)
			{
				_musicSlider.onValueChanged.AddListener(SetMusicVolume);
				_soundSlider.onValueChanged.AddListener(SetSoundVolume);
			}
			else
			{
				Debug.LogError("AudioManager not found!");
			}
		}

		private void SetMusicVolume(float volume)
		{
			AudioManager.Instance.SetMusicVolume(volume);
		}

		private void SetSoundVolume(float volume)
		{
			AudioManager.Instance.SetSoundVolume(volume);
		}
	}
}