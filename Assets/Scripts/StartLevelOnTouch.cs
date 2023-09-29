using UnityEngine;
using UnityEngine.EventSystems;

public class StartLevelOnTouch : MonoBehaviour
{
	void Update()
	{
		if (!Input.GetMouseButtonUp(0))
		{
			return;
		}

		if (Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.right, 0.0001f))
		{
			return;
		}

		SwitchLevelStatus();
	}

	private void SwitchLevelStatus() 
	{
		if (LevelManager.LevelStarted)
		{
			LevelManager.Instance.StopLevel();
		}
		else
		{
			LevelManager.Instance.StartLevel();
		}
	}
}
