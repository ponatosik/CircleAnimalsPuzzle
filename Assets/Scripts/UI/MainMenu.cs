using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public void Quit_game()
    {
        Application.Quit();
    }

    public void Continue_game()
    {
        Level LastUnlcockedLevel = LevelSystem.Instance.GetLastUnlcockedLevel();

        if (LastUnlcockedLevel != null)
        {
            LevelSystem.Instance.LoadLevel(LastUnlcockedLevel);
        }
    }
}
