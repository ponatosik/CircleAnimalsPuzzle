using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySound("FinishSound");

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