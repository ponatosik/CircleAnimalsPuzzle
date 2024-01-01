using TMPro;
using UnityEngine;

namespace CircleAnimalsPuzzle.UI
{
	public class StarCounter : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI StarsText;

		void Start()
		{
			ShowStars();
		}

		void OnEnable()
		{
			ShowStars();
		}

		private void ShowStars()
		{
			int collectedStars = LevelSystem.Instance.TotalStarsCollected;
			int totalStars = LevelSystem.Instance.TotalStars;

			StarsText.text = collectedStars.ToString() + " / " + totalStars.ToString();
		}
	}
}