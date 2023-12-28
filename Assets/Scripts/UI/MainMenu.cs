using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI StarsText;

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

    void Update()
    {
        show_stars();
    }

    public void show_stars()
    {
        int collectedStars = LevelSystem.Instance.TotalStarsCollected;
        int totalStars = LevelSystem.Instance.TotalStars;

        StarsText.text = collectedStars.ToString() + " / " + totalStars.ToString();
    }
}
