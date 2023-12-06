using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    private float originalMusicVolume;
    private float originalSoundVolume;

    public Sound[] _music;
    public Sound[] _sounds;

    private Coroutine fadingCoroutine;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
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
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
        sound.source.loop = sound.loop;
    }

    public void PlayMusic(string musicName, float fadeDuration = 0f)
    {
        Sound music = Array.Find(_music, item => item.name == musicName);
        if (music != null)
        {
            if (fadeDuration > 0)
            {
                if (fadingCoroutine != null)
                {
                    StopCoroutine(fadingCoroutine);
                }
                fadingCoroutine = StartCoroutine(FadeInMusic(music, fadeDuration));
            }
            else
            {
                music.source.Play();
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
        music.source.volume = startVolume;
        music.source.Play();

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            music.source.volume = Mathf.Lerp(startVolume, music.volume, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        music.source.volume = music.volume;
    }

    IEnumerator FadeOutMusic(Sound music, float duration)
    {
        float startVolume = music.volume;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            music.source.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        music.source.Stop();
        music.source.volume = startVolume;
    }

    public void StopMusic(string musicName, float fadeDuration = 0f)
    {
        Sound music = Array.Find(_music, item => item.name == musicName);
        if (music != null)
        {
            if (fadeDuration > 0)
            {
                if (fadingCoroutine != null)
                {
                    StopCoroutine(fadingCoroutine);
                }
                fadingCoroutine = StartCoroutine(FadeOutMusic(music, fadeDuration));
            }
            else
            {
                music.source.Stop();
            }
        }
        else
        {
            Debug.LogWarning("Music " + musicName + " not found");
        }
    }

    public void PlaySound(string soundName)
    {
        Sound sound = Array.Find(_sounds, item => item.name == soundName);
        if (sound != null)
        {
            sound.source.Play();
        }
        else
        {
            Debug.LogWarning("Sound " + soundName + " not found");
        }
    }

    public void StopSound(string soundName)
    {
        Sound sound = Array.Find(_sounds, item => item.name == soundName);
        if (sound != null)
        {
            sound.source.Stop();
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
            s.source.volume = volume;
        }
    }

    public void SetSoundVolume(float volume)
    {
        foreach (Sound s in _sounds)
        {
            s.source.volume = volume;
        }
    }

    public float GetMusicVolume()
    {
        return _music.Length > 0 ? _music[0].source.volume : 0f;
    }

    public float GetSoundVolume()
    {
        return _sounds.Length > 0 ? _sounds[0].source.volume : 0f;
    }

    public void MuteSound()
    {
        originalSoundVolume = GetSoundVolume();
        SetSoundVolume(0);
    }

    public void MuteMusic()
    {
        originalMusicVolume = GetMusicVolume();
        SetMusicVolume(0);
    }

    public void UnmuteSound()
    {
        SetSoundVolume(originalSoundVolume);
    }

    public void UnmuteMusic()
    {
        SetMusicVolume(originalMusicVolume);
    }
}
