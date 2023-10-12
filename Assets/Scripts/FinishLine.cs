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
            StartCoroutine(LoadNextSceneWithDelay(5f));
        }
    }

    IEnumerator LoadNextSceneWithDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        GameManager.Instance.LoadNextLevel();
    }
}