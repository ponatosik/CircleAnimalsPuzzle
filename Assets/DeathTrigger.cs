using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if (collision == null)
        if (collision.gameObject == Player)
        {
          //check active level state when physics work(level started)
          LevelManager.Instance.StopLevel();
        }
    }
}
