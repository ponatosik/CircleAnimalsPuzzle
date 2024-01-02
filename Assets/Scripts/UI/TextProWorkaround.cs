using ntw.CurvedTextMeshPro;
using UnityEngine;

namespace CircleAnimalsPuzzle.UI
{
	[RequireComponent(typeof(TextProOnACurve))]
	public class TextProWorkaround : MonoBehaviour
	{
		private TextProOnACurve _text;
		private Vector2Int _screenResolution = new();

		void Start()
		{
			_text = GetComponent<TextProOnACurve>();
			_screenResolution.x = Screen.width;
			_screenResolution.y = Screen.height;
		}

		void Update()
		{
			if (_screenResolution.x != Screen.width || _screenResolution.y != Screen.height)
			{
				_text.enabled = false;
				Debug.LogWarning($"{nameof(TextProWorkaround)}: Resolution have changed, updating text");
				_screenResolution.x = Screen.width;
				_screenResolution.y = Screen.height;
				_text.enabled = true;
			}
		}
	}
}