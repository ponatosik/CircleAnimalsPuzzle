using UnityEngine;
using UnityEngine.EventSystems;

public class StartLevelOnTouch : MonoBehaviour
{
	GameManager manager;

	void Update()
	{
		if (!Input.GetMouseButtonUp(0) || CheckClickOnObject() || manager.GamePaused)
		{
			return;
		}

		SwitchLevelStatus();
	}

	private void Start()
	{
		manager = GameManager.Instance;
	}

	private void SwitchLevelStatus() 
	{
		if (GameManager.LevelStarted)
		{
			GameManager.Instance.StopLevel();
		}
		else
		{
			GameManager.Instance.StartLevel();
		}
	}

	private bool CheckClickOnObject() 
	{
		return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.right, 0.0001f);
	}
}
