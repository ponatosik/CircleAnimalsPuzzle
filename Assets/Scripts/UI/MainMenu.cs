using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Quit_game()
    {
        Application.Quit();
    }

    public void Continue_game()
    {
        Level LastUnlcockedLevel = LevelSystem.Instance.GetLastUnlcockedLevel();

        if(LastUnlcockedLevel != null)
        {
            LevelSystem.Instance.LoadLevel(LastUnlcockedLevel);
        }
    }
}
