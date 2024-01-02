using CircleAnimalsPuzzle.Data;
using System;
using System.Collections;
using UnityEngine;

namespace CircleAnimalsPuzzle.Systems
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager Instance;

		private float _originalMusicVolume;
		private float _originalSoundVolume;

		public Sound[] _music;
		public Sound[] _sounds;

		private Coroutine _fadingCoroutine;

		void Awake()
		{
			if (Instance != null)
			{
				Destroy(gameObject);
				return;
			}
			else
			{
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}

			foreach (Sound s in _music)
			{
				InitializeAudioSource(s);
			}

			foreach (Sound s in _sounds)
			{
				InitializeAudioSource(s);
			}
		}

		void InitializeAudioSource(Sound sound)
		{
			sound.Source = gameObject.AddComponent<AudioSource>();
			sound.Source.clip = sound.Clip;
			sound.Source.volume = sound.Volume;
			sound.Source.pitch = sound.Pitch;
			sound.Source.loop = sound.Loop;
		}

		public void PlayMusic(string musicName, float fadeDuration = 0f)
		{
			Sound music = Array.Find(_music, item => item.Name == musicName);
			if (music != null)
			{
				if (fadeDuration > 0)
				{
					if (_fadingCoroutine != null)
					{
						StopCoroutine(_fadingCoroutine);
					}
					_fadingCoroutine = StartCoroutine(FadeInMusic(music, fadeDuration));
				}
				else
				{
					music.Source.Play();
				}
			}
			else
			{
				Debug.LogWarning("Music " + musicName + " not found");
			}
		}

		IEnumerator FadeInMusic(Sound music, float duration)
		{
			float startVolume = 0f;
			music.Source.volume = startVolume;
			music.Source.Play();

			float elapsedTime = 0f;

			while (elapsedTime < duration)
			{
				music.Source.volume = Mathf.Lerp(startVolume, music.Volume, elapsedTime / duration);
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			music.Source.volume = music.Volume;
		}

		IEnumerator FadeOutMusic(Sound music, float duration)
		{
			float startVolume = music.Volume;
			float elapsedTime = 0f;

			while (elapsedTime < duration)
			{
				music.Source.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / duration);
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			music.Source.Stop();
			music.Source.volume = startVolume;
		}

		public void StopMusic(string musicName, float fadeDuration = 0f)
		{
			Sound music = Array.Find(_music, item => item.Name == musicName);
			if (music != null)
			{
				if (fadeDuration > 0)
				{
					if (_fadingCoroutine != null)
					{
						StopCoroutine(_fadingCoroutine);
					}
					_fadingCoroutine = StartCoroutine(FadeOutMusic(music, fadeDuration));
				}
				else
				{
					music.Source.Stop();
				}
			}
			else
			{
				Debug.LogWarning("Music " + musicName + " not found");
			}
		}

		public void PlaySound(string soundName)
		{
			Sound sound = Array.Find(_sounds, item => item.Name == soundName);
			if (sound != null)
			{
				sound.Source.Play();
			}
			else
			{
				Debug.LogWarning("Sound " + soundName + " not found");
			}
		}

		public void StopSound(string soundName)
		{
			Sound sound = Array.Find(_sounds, item => item.Name == soundName);
			if (sound != null)
			{
				sound.Source.Stop();
			}
			else
			{
				Debug.LogWarning("Sound " + soundName + " not found");
			}
		}

		public void SetMusicVolume(float volume)
		{
			foreach (Sound s in _music)
			{
				s.Source.volume = volume;
			}
		}

		public void SetSoundVolume(float volume)
		{
			foreach (Sound s in _sounds)
			{
				s.Source.volume = volume;
			}
		}

		public float GetMusicVolume()
		{
			return _music.Length > 0 ? _music[0].Source.volume : 0f;
		}

		public float GetSoundVolume()
		{
			return _sounds.Length > 0 ? _sounds[0].Source.volume : 0f;
		}

		public void MuteSound()
		{
			_originalSoundVolume = GetSoundVolume();
			SetSoundVolume(0);
		}

		public void MuteMusic()
		{
			_originalMusicVolume = GetMusicVolume();
			SetMusicVolume(0);
		}

		public void UnmuteSound()
		{
			SetSoundVolume(_originalSoundVolume);
		}

		public void UnmuteMusic()
		{
			SetMusicVolume(_originalMusicVolume);
		}
	}
}