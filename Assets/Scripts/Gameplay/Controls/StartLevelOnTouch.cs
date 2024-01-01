using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CircleAnimalsPuzzle.Gameplay.Controls
{
	public class StartLevelOnTouch : MonoBehaviour
	{
		private GameManager _manager;
		private GraphicRaycaster _graphicRaycaster;

		void Update()
		{
			if (Input.GetMouseButtonUp(0) && !CheckClickOnObject() && !_manager.GamePaused)
			{
				SwitchLevelStatus();
			}
		}

		private void Start()
		{
			_manager = GameManager.Instance;
			_graphicRaycaster = FindObjectOfType<GraphicRaycaster>();
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
			if (Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.right, 0.0001f))
			{
				return true;
			}

			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = Input.mousePosition;
			List<RaycastResult> UIClicks = new();
			_graphicRaycaster.Raycast(pointerEventData, UIClicks);

			return UIClicks.Any();
		}
	}
}