using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    public void StartThisLevel(Level level)
    {
        if (level != null && level.Unlocked)
        {
            LevelSystem.Instance.LoadLevel(level);
        }
    }
}
