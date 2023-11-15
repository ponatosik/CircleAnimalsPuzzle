using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    public void StartThisLevel(Level level)
    {
        if (level != null && level.Unclocked)
        {
            LevelSystem.Instance.LoadLevel(level);
        }
    }
}
