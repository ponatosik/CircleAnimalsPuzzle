using UnityEngine;
using UnityEngine.UI;

namespace CircleAnimalsPuzzle.UI
{
	public class SkinsSwipe : MonoBehaviour
	{
		public Scrollbar Scrollbar;
		private float _scrollPos = 0;
		private float[] _pos;
		private float _distance = 1f;

		void Start()
		{
			_pos = new float[transform.childCount];
			_distance = 1f / (_pos.Length - 1f);

			for (int i = 0; i < _pos.Length; i++)
			{
				_pos[i] = _distance * i;
			}
		}

		void Update()
		{
			if (Input.GetMouseButton(0))
			{
				_scrollPos = Scrollbar.value;
			}
			else
			{
				CenterOnItem();
			}
		}

		public void ScrollLeft()
		{
			int currentIndex = Mathf.RoundToInt(Scrollbar.GetComponent<Scrollbar>().value / _distance);
			int targetIndex = Mathf.Clamp(currentIndex - 1, 0, _pos.Length - 1);
			Scrollbar.GetComponent<Scrollbar>().value = _pos[targetIndex];
		}

		public void ScrollRight()
		{
			int currentIndex = Mathf.RoundToInt(Scrollbar.GetComponent<Scrollbar>().value / _distance);
			int targetIndex = Mathf.Clamp(currentIndex + 1, 0, _pos.Length - 1);
			Scrollbar.GetComponent<Scrollbar>().value = _pos[targetIndex];
		}

		private void CenterOnItem()
		{
			for (int i = 0; i < _pos.Length; i++)
			{
				if (_scrollPos < _pos[i] + (_distance / 2) && _scrollPos > _pos[i] - (_distance / 2))
				{
					Scrollbar.value = Mathf.Lerp(Scrollbar.value, _pos[i], 0.1f);
				}
			}
		}
	}
}