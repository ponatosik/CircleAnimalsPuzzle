using CircleAnimalsPuzzle.UI.Hints;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CircleAnimalsPuzzle.Systems
{
	public class HintManager : MonoBehaviour
	{
		public static HintManager Instance { get; private set; }

		[SerializeField]
		private List<HintObject> _hints = new List<HintObject>();

		[SerializeField]
		private List<HintObject> _displayedHints = new List<HintObject>();

		public int HintsLeft => _hints.Count;

		public void DisplayRandomHint()
		{
			if (HintsLeft == 0)
			{
				Debug.LogWarning("No hints left to display");
			}

			HintObject randomHint = _hints[Random.Range(0, _hints.Count)];
			_hints.Remove(randomHint);
			randomHint.Display();
			_displayedHints.Add(randomHint);
		}

		void Awake()
		{
			if (Instance != null)
			{
				Debug.Log($"Attempt to create second instance of {nameof(HintManager)}");
				Destroy(gameObject);
				return;
			}

			Instance = this;
		}

		private void Start()
		{
			_hints.AddRange(FindObjectsOfType<HintObject>().Where(hint => !_hints.Contains(hint)));
			Debug.Log($"Found {_hints.Count} hints on level");
		}
	}
}