using UnityEngine;
using CircleAnimalsPuzzle.Data;

namespace CircleAnimalsPuzzle.UI
{
	public class MainMenu : MonoBehaviour
	{
		public void QuitGame()
		{
			Application.Quit();
		}

		public void ContinueGame()
		{
			Level LastUnlcockedLevel = LevelSystem.Instance.GetLastUnlockedLevel();

			if (LastUnlcockedLevel != null)
			{
				LevelSystem.Instance.LoadLevel(LastUnlcockedLevel);
			}
		}
	}
}