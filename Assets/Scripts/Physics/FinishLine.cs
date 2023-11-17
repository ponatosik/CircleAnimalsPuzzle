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
            StartCoroutine(LoadNextSceneWithDelay(2f));
        }
    }

    IEnumerator LoadNextSceneWithDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        GameObject canvasObject = GameObject.FindGameObjectWithTag("LevelUI");

        if (canvasObject != null)
        {
            Transform finishMenuTransform = canvasObject.transform.Find("Finish menu");

            if (finishMenuTransform != null)
            {
                GameObject finishMenu = finishMenuTransform.gameObject;

                finishMenu.SetActive(true);
            }
        }
    }
}