using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player) {
            // for next scene   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Level finished");
        }
    }
}
