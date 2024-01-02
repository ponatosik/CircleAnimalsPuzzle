using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace CircleAnimalsPuzzle.Data
{
	[System.Serializable]
	public class Sound
	{
		public string Name;
		public AudioClip Clip;
		public bool Loop = false;

		[Range(0f, 1f)]
		public float Volume = 1;
		[Range(0f, 3f)]
		public float Pitch = 1;

		[HideInInspector]
		public AudioSource Source;
	}
}