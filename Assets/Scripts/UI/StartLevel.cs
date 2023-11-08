using UnityEngine;
using UnityEngine.UI;

public class StartLevelButton : MonoBehaviour
{
    //[SerializeField] Level level;

    public void StartFirstLevel(Level level)
    {
        LevelSystem.Instance.LoadLevel(level);
    }
}
