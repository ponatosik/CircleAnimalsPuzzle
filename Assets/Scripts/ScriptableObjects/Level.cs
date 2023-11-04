using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu (fileName = "Level", menuName = "Scriptable objects/Level")]
public class Level : ScriptableObject
{
	public string SceneName = "Level";
	public bool Unclocked = false;
	public int Stars = 0;
	public int MaxStars = 3;
}
