using UnityEngine;

namespace CircleAnimalsPuzzle.UI.Hints
{
	public class HintObject : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		public void Display()
		{
			_renderer.enabled = true;
		}

		private void Awake()
		{
			_renderer.enabled = false;
		}
	}
}