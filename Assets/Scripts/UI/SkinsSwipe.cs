using UnityEngine;
using UnityEngine.UI;

namespace CircleAnimalsPuzzle.UI
{
    public class SkinsSwipe : MonoBehaviour
    {
        public Scrollbar Scrollbar;
        public Button ScrollLeftButton;
        public Button ScrollRightButton;

        private float[] _pos;
        private float _distance = 1f;
        private bool _isScrolling = false;

        void Start()
        {
            _pos = new float[transform.childCount];
            _distance = 1f / (_pos.Length - 1f);

            for (int i = 0; i < _pos.Length; i++)
            {
                _pos[i] = _distance * i;
            }

            UpdateButtonVisibility();

            if (ScrollLeftButton != null)
            {
                ScrollLeftButton.gameObject.SetActive(false);
            }
        }



        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _isScrolling = true;
            }
            else if (_isScrolling)
            {
                CenterOnItem();
                _isScrolling = false;
                UpdateButtonVisibility();
            }
        }

        public void ScrollLeft()
        {
            Scroll(-1);
            UpdateButtonVisibility();
        }

        public void ScrollRight()
        {
            Scroll(1);
            UpdateButtonVisibility();
        }

        private void Scroll(int direction)
        {
            int currentIndex = Mathf.RoundToInt(Scrollbar.value / _distance);
            int targetIndex = Mathf.Clamp(currentIndex + direction, 0, _pos.Length - 1);
            Scrollbar.value = _pos[targetIndex];
        }

        private void CenterOnItem()
        {
            float targetValue = 0f;
            float smallestDifference = float.MaxValue;

            for (int i = 0; i < _pos.Length; i++)
            {
                float difference = Mathf.Abs(_pos[i] - Scrollbar.value);
                if (difference < smallestDifference)
                {
                    smallestDifference = difference;
                    targetValue = _pos[i];
                }
            }

            Scrollbar.value = targetValue;
        }

        private void UpdateButtonVisibility()
        {
            bool isFirstCard = Mathf.Approximately(Scrollbar.value, _pos[0]);
            bool isLastCard = Mathf.Approximately(Scrollbar.value, _pos[_pos.Length - 1]);

            if (ScrollLeftButton != null)
            {
                ScrollLeftButton.gameObject.SetActive(!isFirstCard);
            }

            if (ScrollRightButton != null)
            {
                ScrollRightButton.gameObject.SetActive(!isLastCard);
            }
        }
    }
}
