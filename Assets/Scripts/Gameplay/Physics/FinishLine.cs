using CircleAnimalsPuzzle.Systems;
using CircleAnimalsPuzzle.UI;
using System.Collections;
using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Physics
{
	public class FinishLine : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Player"))
			{
				AudioManager.Instance.PlaySound("FinishSound");

				StartCoroutine(LoadNextSceneWithDelay(2f));
			}
		}

		IEnumerator LoadNextSceneWithDelay(float delayInSeconds)
		{
			GameManager.Instance.CompleteLevelWithDelay(delayInSeconds);
			yield return new WaitForSeconds(delayInSeconds);
			int collectedNumber = GameManager.Instance.Collectables.GetCollectedNumber();
			Starsinlevel.OutputCollectedNumber();
		}
	}
}