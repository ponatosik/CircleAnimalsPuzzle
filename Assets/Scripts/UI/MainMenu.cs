using UnityEngine;
using CircleAnimalsPuzzle.Data;

namespace CircleAnimalsPuzzle.UI
{
	public class MainMenu : MonoBehaviour
	{
		public void Quit_game()
		{
			Application.Quit();
		}

		public void Continue_game()
		{
			Level LastUnlcockedLevel = LevelSystem.Instance.GetLastUnlockedLevel();

			if (LastUnlcockedLevel != null)
			{
				LevelSystem.Instance.LoadLevel(LastUnlcockedLevel);
			}
		}
	}
}